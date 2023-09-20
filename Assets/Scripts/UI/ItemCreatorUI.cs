using TMPro;
using UnityEngine;

public class ItemCreatorUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _selectedItemDataName;

    private ItemManager _itemManager;

    void Start()
    {
        GameManager.Instance.TryGetManager(out _itemManager);
        _itemManager.OnItemDataSelected += ItemCreatorUIOnItemDataSelected;
    }

    void OnDestroy()
    {
        _itemManager.OnItemDataSelected -= ItemCreatorUIOnItemDataSelected;
    }

    public void CreateItemButton() => _itemManager.CreateItem();
    public void CreateRandomItemButton() => _itemManager.CreateRandomItem();
    public void SelectNextItemDataButton() => _itemManager.SelectNextItemData();
    public void SelectPreviousItemDataButton() => _itemManager.SelectPreviousItemData();

    private void ItemCreatorUIOnItemDataSelected(ItemData selectedItemData)
    {
        _selectedItemDataName.text = selectedItemData.ItemName;
    }
}
