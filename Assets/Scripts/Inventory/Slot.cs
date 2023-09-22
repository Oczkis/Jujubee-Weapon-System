using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int SlotIndex { get; private set; }
    public Weapon Weapon { get; private set; }
    public Image WeaponIcon => _weaponIcon;
    public Image SlotFrame => _slotFrame;

    [SerializeField] private Image _slotFrame;
    [SerializeField] private Image _weaponIcon;

    public void SetIndex(int slotIndex) => SlotIndex = slotIndex;

    public void PlaceWeapon(Weapon weapon)
    {
        Weapon = weapon;
    }
}
