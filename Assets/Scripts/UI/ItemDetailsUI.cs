using TMPro;
using UnityEngine;

public class ItemDetailsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemNameText, _weaponTypeText, _descriptionText;

    private InventoryManager _inventoryManager;

    void Start()
    {
        GameManager.Instance.TryGetManager(out _inventoryManager);

        _inventoryManager.OnSlotSelected += ItemDetailsUIOnSlotSelected;
    }

    void OnDestroy()
    {
        _inventoryManager.OnSlotSelected -= ItemDetailsUIOnSlotSelected;
    }

    private void ItemDetailsUIOnSlotSelected(Slot slot)
    {
        Weapon item = slot.Weapon;

        if (item == null) return;

        SetTexts(item);
    }

    private void SetTexts(Weapon weapon)
    {
        _weaponTypeText.text = weapon.WeaponType.ToString();
        _descriptionText.text = weapon.GetDescription();
        _itemNameText.text = weapon.WeaponName;
    }
}
