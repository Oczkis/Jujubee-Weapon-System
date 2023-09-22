using static Helpers;
using UnityEngine;

public class WeaponData : ScriptableObject, IUseable
{
    public WeaponType WeaponType => GetWeaponType();
    public Sprite WeaponIcon;
    public string WeaponName;
    public Mesh WeaponModel;
    public int WeaponDamage;

    public virtual void Use() { }

    public virtual WeaponType GetWeaponType() { return WeaponType.Sidearm; }

    public virtual string GetDescription()
    {
        return "Weapon Damage : " + WeaponDamage.ToString() + "\n";
    }
}
