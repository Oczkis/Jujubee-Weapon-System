using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponManager : MonoBehaviour, IManager
{
    [SerializeField] private WeaponData[] _weaponDatabase = new WeaponData[0];

    public Action<WeaponData> OnWeaponDataSelected;
    public Action<Weapon> OnWeaponCreated;

    private WeaponData _weaponDataSelected = null;
    private int _weaponDataSelectedIndex = 0;

    void Start()
    {
        SelectWeaponData(_weaponDatabase[0]);
        CreateRandomWeapon();
    }

    public void CreateRandomWeapon() => CreateWeapon(_weaponDatabase[Random.Range(0, _weaponDatabase.Length)]);
    public void CreateWeapon() => CreateWeapon(_weaponDataSelected);

    public void SelectNextWeaponData()
    {
        _weaponDataSelectedIndex = (_weaponDataSelectedIndex + 1) % _weaponDatabase.Length;
        SelectWeaponData(_weaponDatabase[_weaponDataSelectedIndex]);
    }

    public void SelectPreviousWeaponData()
    {
        _weaponDataSelectedIndex = (_weaponDataSelectedIndex - 1) % _weaponDatabase.Length;
        SelectWeaponData(_weaponDatabase[_weaponDataSelectedIndex]);
    }

    private void CreateWeapon(WeaponData weaponData)
    {
        Weapon newWeapon = new Weapon(weaponData);
        OnWeaponCreated?.Invoke(newWeapon);
    }

    private void SelectWeaponData(WeaponData weaponData)
    {
        _weaponDataSelected = weaponData;
        OnWeaponDataSelected?.Invoke(_weaponDataSelected);
    }
}
