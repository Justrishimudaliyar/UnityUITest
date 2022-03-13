using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Controller_Weapon primaryWeapon1;
    private Controller_Weapon primaryWeapon2;
    private Controller_Weapon secondaryWeapon;
    private Controller_Weapon equippedWeapon;
    private int health;

    void Start()
    {
        InitializePlayer();
        SubscribeToEvents();
    }

    private void InitializePlayer()
    {
        primaryWeapon1 = null;
        primaryWeapon2 = null;
        secondaryWeapon = null;
        equippedWeapon = null;
    }

    private void SubscribeToEvents()
    {
        InputManager.OnPickWeaponInput += PickWeapon;
        InputManager.OnDropWeaponInput += DropWeapon;
        InputManager.OnSwitchWeaponInput += SwitchWweapon;
        InputManager.OnAttackInput += Attack;
        InputManager.OnReloadInput += ReloadEquippedWeapon;
    }

    private void PickWeapon(Controller_Weapon weaponToBePicked)
    {
        if (weaponToBePicked.Model.Type == Type_Weapon.Primary)
        {
            PickUpSecondaryWeapon(weaponToBePicked);
        }
        else if (weaponToBePicked.Model.Type == Type_Weapon.Secondary)
        {
            PickUpPrimaryWeapon(weaponToBePicked);
        }

        if (equippedWeapon == null)
        {
            equippedWeapon = weaponToBePicked;
        }

        UIHandler.Instance.UpdateWeaponUI(weaponToBePicked);
    }

    private void PickUpPrimaryWeapon(Controller_Weapon weaponToBePicked)
    {
        if (primaryWeapon1 == null)
        {
            primaryWeapon1 = weaponToBePicked;
            weaponToBePicked.Model.SlotType = SlotType_Weapon.PrimaryWeapon1;

        }
        else if (primaryWeapon2 == null)
        {
            primaryWeapon2 = weaponToBePicked;
            weaponToBePicked.Model.SlotType = SlotType_Weapon.PrimaryWeapon2;
        }
        else
        {
            DropWeapon(primaryWeapon1);
            primaryWeapon1 = weaponToBePicked;
            weaponToBePicked.Model.SlotType = SlotType_Weapon.PrimaryWeapon1;
        }
    }

    private void PickUpSecondaryWeapon(Controller_Weapon weaponToBePicked)
    {
        if (secondaryWeapon == null)
        {
            secondaryWeapon = weaponToBePicked;
            weaponToBePicked.Model.SlotType = SlotType_Weapon.SecondaryWeapon;
        }
        else
        {
            DropWeapon(secondaryWeapon);
            secondaryWeapon = weaponToBePicked;
            weaponToBePicked.Model.SlotType = SlotType_Weapon.SecondaryWeapon;
        }
    }

    private void DropWeapon(Controller_Weapon weaponToDrop)
    {
        if (equippedWeapon == weaponToDrop)
        {
            equippedWeapon = null;
        }

        if (primaryWeapon1 == weaponToDrop)
        {
            primaryWeapon1 = null;
        }
        else if (primaryWeapon2 == weaponToDrop)
        {
            primaryWeapon2 = null;
        }
        else if (secondaryWeapon == weaponToDrop)
        {
            secondaryWeapon = null;
        }
        UIHandler.Instance.DeleteUIReference(weaponToDrop);
        weaponToDrop.Model.SlotType = SlotType_Weapon.None;
    }

    private void SwitchWweapon(Controller_Weapon weaponToEquip)
    {
        equippedWeapon = weaponToEquip;
    }

    private void Attack()
    {
        if (equippedWeapon != null)
        {
            equippedWeapon.Fire();
        }
        else
        {
            MeleeAttack();
        }
    }

    private void MeleeAttack()
    {

    }

    private void ReloadEquippedWeapon()
    {
        if (equippedWeapon != null) equippedWeapon.Reload();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            
        }
    }


    private void OnDisable()
    {
        DeSubscribeToEvents();
    }

    private void DeSubscribeToEvents()
    {
        InputManager.OnPickWeaponInput -= PickWeapon;
        InputManager.OnDropWeaponInput -= DropWeapon;
        InputManager.OnSwitchWeaponInput -= SwitchWweapon;
        InputManager.OnAttackInput -= Attack;
        InputManager.OnReloadInput -= ReloadEquippedWeapon;
    }

}

