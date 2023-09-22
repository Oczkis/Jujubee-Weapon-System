using UnityEngine;
using static Helpers;

public class Weapon
{
    public WeaponType WeaponType { get; private set; }
    public WeaponData WeaponData { get; private set; }
    public Sprite WeaponIcon { get; private set; }
    public string WeaponName { get; private set; }
    public Mesh WeaponModel { get; private set; }
    public int WeaponDamage { get; private set; }
    public int Strength { get; private set; }
    public int Agility { get; private set; }

    public Weapon(WeaponData weaponData)
    {
        WeaponDamage = weaponData.WeaponDamage;
        WeaponModel = weaponData.WeaponModel;
        WeaponType = weaponData.WeaponType;
        WeaponIcon = weaponData.WeaponIcon;
        WeaponName = weaponData.WeaponName;
        WeaponData = weaponData;
        RandomizeStats();
    }

    public void UseItem() => WeaponData.Use();

    public string GetDescription()
    {
        return WeaponData.GetDescription()
        + "Strength : " + Strength.ToString() + "\n"
        + "Agility : " + Agility.ToString() + "\n";
    }

    private void RandomizeStats()
    {
        Strength = Random.Range(0, 3);
        Agility = Random.Range(0, 3);
    }
}
