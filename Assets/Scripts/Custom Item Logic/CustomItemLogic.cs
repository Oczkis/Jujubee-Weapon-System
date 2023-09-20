using static Helpers;
using UnityEngine;

public abstract class CustomItemLogic : MonoBehaviour
{
    public WeaponType WeaponType;

    public abstract void UseItem();
}
