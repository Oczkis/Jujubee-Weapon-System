using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private InventoryManager _inventoryManager;

    void Start()
    {
        GameManager.Instance.TryGetManager(out _inventoryManager);

        _inventoryManager.OnSlotDeselected += InventoryUIOnSlotDeselected;
        _inventoryManager.OnSlotSelected += InventoryUIOnSlotSelected;
        _inventoryManager.OnSlotCreated += InventoryUIOnSlotCreated;
        _inventoryManager.OnSlotUpdated += InventoryUIOnSlotUpdated;
    }

    void OnDestroy()
    {
        _inventoryManager.OnSlotDeselected -= InventoryUIOnSlotDeselected;
        _inventoryManager.OnSlotSelected -= InventoryUIOnSlotSelected;
        _inventoryManager.OnSlotCreated -= InventoryUIOnSlotCreated;
        _inventoryManager.OnSlotUpdated -= InventoryUIOnSlotUpdated;
    }
    private void InventoryUIOnSlotDeselected(Slot deselectedSlot)
    {
        deselectedSlot.SlotFrame.enabled = false;
    }

    private void InventoryUIOnSlotSelected(Slot selectedSlot)
    {
        selectedSlot.SlotFrame.enabled = true;
    }

    private void InventoryUIOnSlotCreated(Slot newSlot)
    {
        newSlot.transform.SetParent(transform);
    }

    private void InventoryUIOnSlotUpdated(Slot updatedSlot)
    {
        updatedSlot.WeaponIcon.sprite = updatedSlot.Weapon.WeaponIcon;
    }
}
