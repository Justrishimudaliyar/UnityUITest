using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class InputManager : SingletonGenericScript<InputManager>
{
    public static event Action<Controller_Weapon> OnPickWeaponInput;
    public static event Action<Controller_Weapon> OnDropWeaponInput;
    public static event Action<Controller_Weapon> OnSwitchWeaponInput;
    public static event Action OnAttackInput;
    public static event Action OnReloadInput;
    public static event Action<int> OnHit;


    private void GetWeaponToPick(Controller_Weapon weaponToPick)
    {
        OnPickWeaponInput?.Invoke(weaponToPick);
    }

    private void GetWeaponToDrop(Controller_Weapon weaponToDrop)
    {
        OnDropWeaponInput?.Invoke(weaponToDrop);
    }

    private void GetWeaponToSwitch(Controller_Weapon weaponToSwitch)
    {
        OnSwitchWeaponInput?.Invoke(weaponToSwitch);
    }

    private void Attack()
    {
        OnAttackInput?.Invoke();
    }

    private void Reload()
    {
        OnReloadInput?.Invoke();
    }

    private void TakeDamage(int damage)
    {
        OnHit?.Invoke(damage);
    }

}

