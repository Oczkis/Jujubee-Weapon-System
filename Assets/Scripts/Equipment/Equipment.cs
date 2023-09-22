using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private MeshFilter _weaponSpotMeshFilter;

    private InventoryManager _inventoryManager;
    private InputManager _inputManager;

    private Weapon _itemEquipped;

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
        Weapon item = slot.Weapon;
        if (item == null) return;

        _weaponSpotMeshFilter.sharedMesh = item.WeaponModel;
        _itemEquipped = item;
    }

    private void EquipmentOnMousePressed(bool left)
    {
        if (!left) return;
        if (_itemEquipped == null) return;

        _itemEquipped.UseItem();
    }
}
