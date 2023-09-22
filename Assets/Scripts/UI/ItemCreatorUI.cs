using TMPro;
using UnityEngine;

public class ItemCreatorUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _selectedItemDataName;

    private WeaponManager _itemManager;

    void Start()
    {
        GameManager.Instance.TryGetManager(out _itemManager);

        _itemManager.OnWeaponDataSelected += ItemCreatorUIOnItemDataSelected;
    }

    void OnDestroy()
    {
        _itemManager.OnWeaponDataSelected -= ItemCreatorUIOnItemDataSelected;
    }

    public void SelectPreviousItemDataButton() => _itemManager.SelectPreviousWeaponData();
    public void SelectNextItemDataButton() => _itemManager.SelectNextWeaponData();
    public void CreateRandomItemButton() => _itemManager.CreateRandomWeapon();
    public void CreateItemButton() => _itemManager.CreateWeapon();

    private void ItemCreatorUIOnItemDataSelected(WeaponData selectedItemData)
    {
        _selectedItemDataName.text = selectedItemData.WeaponName;
    }
}
