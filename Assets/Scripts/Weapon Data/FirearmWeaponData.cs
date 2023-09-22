using UnityEngine;
using static Helpers;

[CreateAssetMenu(menuName = "Items/Firearm")]
public class FirearmWeaponData : WeaponData
{
    public int AmmoSize;

    public override WeaponType GetWeaponType() { return WeaponType.Firearm; }

    public override string GetDescription()
    {
        return base.GetDescription()
        + "Ammo size " + AmmoSize.ToString() + "\n";
    }

    public override void Use()
    {
        GameManager.Instance.TryGetManager(out PlayerManager playerManager);
        playerManager.LocalPlayer.PlayAnimation("Shoot");
        Debug.Log("Shoot a bullet");
    }
}
