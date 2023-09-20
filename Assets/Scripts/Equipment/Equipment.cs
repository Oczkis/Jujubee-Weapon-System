using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;

    private InventoryManager _inventoryManager;
    private InputManager _inputManager;

    private Item _itemEquipped;

    void Start()
    {
        GameManager.Instance.TryGetManager(out _inventoryManager);
        GameManager.Instance.TryGetManager(out _inputManager);

        _inventoryManager.OnSlotSelected += EquipmentOnSlotSelected;
        _inputManager.OnMousePressed += EquipmentOnMousePressed;
    }

    void OnDestroy()
    {
        _inventoryManager.OnSlotSelected -= EquipmentOnSlotSelected;
        _inputManager.OnMousePressed -= EquipmentOnMousePressed;
    }

    private void EquipmentOnSlotSelected(Slot slot)
    {
        Item item = slot.Item;
        if (item == null) return;

        _meshFilter.mesh = item.WeaponModel;
        _itemEquipped = item;
    }

    private void EquipmentOnMousePressed(bool left)
    {
        if (!left) return;
        if (_itemEquipped == null) return;

        _itemEquipped.CustomItemLogic.UseItem();
    }
}
