using static Helpers;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/New Item")]
public class ItemData : ScriptableObject
{
    public CustomItemLogic CustomItemLogic;
    public WeaponType WeaponType => CustomItemLogic.WeaponType;
    public Mesh WeaponModel;
    public Sprite ItemIcon;
    public string ItemName;
    public int ItemDamage;
    public int AmmoSize;
}
