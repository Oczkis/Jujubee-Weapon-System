using UnityEngine;
using static Helpers;

[CreateAssetMenu(menuName = "Items/Sidearm")]
public class SidearmWeaponData : WeaponData
{
    public float AttackSpeed;

    public override WeaponType GetWeaponType() { return WeaponType.Sidearm; }

    public override string GetDescription()
    {
        return base.GetDescription()
        + "Attack speed " + AttackSpeed.ToString() + "\n";
    }

    public override void Use()
    {
        GameManager.Instance.TryGetManager(out PlayerManager playerManager);
        playerManager.LocalPlayer.PlayAnimation("Slash");
        Debug.Log("Swing a melee weapon");
    }
}
