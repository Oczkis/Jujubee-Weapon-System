using UnityEngine;
using static Helpers;

public class Item
{
    public CustomItemLogic CustomItemLogic { get; private set; }
    public WeaponType WeaponType { get; private set; }
    public Mesh WeaponModel { get; private set; }
    public Sprite ItemIcon { get; private set; }
    public string ItemName { get; private set; }
    public int ItemDamage { get; private set; }
    public int AmmoSize { get; private set; }
    public int Strength { get; private set; }
    public int Agility { get; private set; }

    public Item(ItemData itemData)
    {
        CustomItemLogic = itemData.CustomItemLogic;
        WeaponModel = itemData.WeaponModel;
        WeaponType = itemData.WeaponType;
        ItemDamage = itemData.ItemDamage;
        ItemIcon = itemData.ItemIcon;
        ItemName = itemData.ItemName;
        AmmoSize = itemData.AmmoSize;
        RandomizeStats();
    }

    private void RandomizeStats()
    {
        Strength = Random.Range(0, 3);
        Agility = Random.Range(0, 3);
    }
}
