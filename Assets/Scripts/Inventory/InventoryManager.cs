using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IManager
{
    [SerializeField] private GameObject _slotPrefab;

    public Action<Slot> OnSlotDeselected;
    public Action<Slot> OnSlotSelected;
    public Action<Slot> OnSlotCreated;
    public Action<Slot> OnSlotUpdated;

    private List<Slot> _inventorySlots = new List<Slot>();

    private InputManager _inputManager;
    private WeaponManager _itemManager;

    private Slot _currentSlotSelected;

    private int _numberOfSlots = 7;

    public Slot EmptySlot => _inventorySlots.Find(slot => slot.Weapon == null);
    public Slot LastSlot => _inventorySlots[^1];

    void Start() 
    {
        GameManager.Instance.TryGetManager(out _itemManager);
        GameManager.Instance.TryGetManager(out _inputManager);

        _inputManager.OnMousePressed += InventoryOnMousePressed;
        _itemManager.OnWeaponCreated += InventoryOnItemCreated;

        PopulateInventory();
        SelectSlot(0);
    }

    void OnDestroy()
    {
        _inputManager.OnMousePressed -= InventoryOnMousePressed;
        _itemManager.OnWeaponCreated -= InventoryOnItemCreated;
    }

    private void InventoryOnMousePressed(bool leftMouseButton)
    {
        if (leftMouseButton) return;

        SelectNextSlot();
    }

    private void InventoryOnItemCreated(Weapon item)
    {
        Slot slot = EmptySlot == null ? LastSlot : EmptySlot;
        slot.PlaceWeapon(item);
        OnSlotUpdated?.Invoke(slot);

        if (slot == _currentSlotSelected && slot.Weapon != null)
            SelectSlot(_currentSlotSelected.SlotIndex);
    }

    private void PopulateInventory()
    {
        for (int i = 0; i < _numberOfSlots; i++)
        {
            Slot newSlot = Instantiate(_slotPrefab).GetComponent<Slot>();
            newSlot.SetIndex(_inventorySlots.Count);
            _inventorySlots.Add(newSlot);
            OnSlotCreated?.Invoke(newSlot);
        }
    }

    private void SelectNextSlot()
    {
        int startIndex = _currentSlotSelected == null ? 0 : (_currentSlotSelected.SlotIndex + 1);

        for (int i = 0; i < _inventorySlots.Count; i++)
        {
            int seekIndex = (startIndex + i) % (_inventorySlots.Count);

            if (_inventorySlots[seekIndex].Weapon == null)
                continue;

            SelectSlot(seekIndex);
            return;
        }
    }
    
    private void SelectSlot(int index)
    {
        if (_currentSlotSelected != null) 
            OnSlotDeselected?.Invoke(_currentSlotSelected);

        _currentSlotSelected = _inventorySlots[index];
        OnSlotSelected?.Invoke(_currentSlotSelected);
    }
}
