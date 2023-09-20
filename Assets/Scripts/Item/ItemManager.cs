using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour, IManager
{
    [SerializeField] private ItemData[] _itemDatabase = new ItemData[0];

    public Action<ItemData> OnItemDataSelected;
    public Action<Item> OnItemCreated;

    private ItemData _itemDataSelected = null;
    private int _itemDataSelectedIndex = 0;

    void Start()
    {
        SelectItemData(_itemDatabase[0]);
        CreateRandomItem();
    }

    public void CreateRandomItem() => CreateItem(_itemDatabase[Random.Range(0, _itemDatabase.Length)]);
    public void CreateItem() => CreateItem(_itemDataSelected);

    public void SelectNextItemData()
    {
        _itemDataSelectedIndex = (_itemDataSelectedIndex + 1) % _itemDatabase.Length;
        SelectItemData(_itemDatabase[_itemDataSelectedIndex]);
    }

    public void SelectPreviousItemData()
    {
        _itemDataSelectedIndex = (_itemDataSelectedIndex - 1) % _itemDatabase.Length;
        SelectItemData(_itemDatabase[_itemDataSelectedIndex]);
    }

    private void CreateItem(ItemData itemData)
    {
        Item newItem = new Item(itemData);
        OnItemCreated?.Invoke(newItem);
    }

    private void SelectItemData(ItemData itemData)
    {
        _itemDataSelected = itemData;
        OnItemDataSelected?.Invoke(_itemDataSelected);
    }
}
