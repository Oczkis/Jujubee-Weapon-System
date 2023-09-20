using TMPro;
using UnityEngine;

public class ItemDetailsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemNameText, _weaponTypeText, _ammoSizeText, _weaponDamageText, _weaponStrengthText, _weaponAgilityText;

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
        Item item = slot.Item;

        if (item == null) return;

        SetStatsVisibility(item);
        SetTexts(item);
    }

    private void SetStatsVisibility(Item item)
    {
        _ammoSizeText.gameObject.SetActive(item.AmmoSize > 0);
        _weaponStrengthText.gameObject.SetActive(item.Strength > 0);
        _weaponAgilityText.gameObject.SetActive(item.Agility > 0);
    }

    private void SetTexts(Item item)
    {
        _itemNameText.text = item.ItemName;
        _weaponTypeText.text = item.WeaponType.ToString();
        _ammoSizeText.text = "Ammo " + item.AmmoSize.ToString();
        _weaponDamageText.text = "Weapon Damage : " + item.ItemDamage.ToString();
        _weaponStrengthText.text = "Strength : " + item.Strength.ToString();
        _weaponAgilityText.text = "Agility : " + item.Agility.ToString();
    }
}
