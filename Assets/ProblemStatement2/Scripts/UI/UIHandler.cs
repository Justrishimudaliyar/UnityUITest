using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIHandler : SingletonGenericScript<UIHandler>
{
    public Sprite PrimaryWeapon1Sprite;
    public TextMeshProUGUI AmmoTextPW1;
    public Sprite PrimaryWeapon2Sprite;
    public TextMeshProUGUI AmmoTextPW2;
    public Sprite SecondaryWeaponSprite;
    public TextMeshProUGUI AmmoTextSW;


    public void UpdateWeaponUI(Controller_Weapon weapon)
    {
        if (weapon.Model.SlotType == SlotType_Weapon.PrimaryWeapon1)
        {
            PrimaryWeapon1Sprite = weapon.Model.WeaponSprite;
        }
        else if (weapon.Model.SlotType == SlotType_Weapon.PrimaryWeapon2)
        {
            PrimaryWeapon2Sprite = weapon.Model.WeaponSprite;
        }
        else if (weapon.Model.SlotType == SlotType_Weapon.SecondaryWeapon)
        {
            SecondaryWeaponSprite = weapon.Model.WeaponSprite;
        }
        else if (weapon.Model.SlotType == SlotType_Weapon.None)
        {

        }
    }

    public void DeleteUIReference(Controller_Weapon weapon)
    {
        if (weapon.Model.SlotType == SlotType_Weapon.PrimaryWeapon1)
        {
            PrimaryWeapon1Sprite = null;
            AmmoTextPW1.text = "";
        }
        else if (weapon.Model.SlotType == SlotType_Weapon.PrimaryWeapon2)
        {
            PrimaryWeapon2Sprite = null;
            AmmoTextPW2.text = "";
        }
        else if (weapon.Model.SlotType == SlotType_Weapon.SecondaryWeapon)
        {
            SecondaryWeaponSprite = null;
            AmmoTextSW.text = "";
        }
    }

    public void UpdateAmmoUI(Controller_Weapon weapon)
    {
        if (weapon.Model.SlotType == SlotType_Weapon.PrimaryWeapon1)
        {
            AmmoTextPW1.text = weapon.Model.AmmoInMag.ToString() + "/" + weapon.Model.Ammo.ToString();
        }
        else if (weapon.Model.SlotType == SlotType_Weapon.PrimaryWeapon2)
        {
            AmmoTextPW2.text = weapon.Model.AmmoInMag.ToString() + "/" + weapon.Model.Ammo.ToString();
        }
        else if (weapon.Model.SlotType == SlotType_Weapon.SecondaryWeapon)
        {
            AmmoTextSW.text = weapon.Model.AmmoInMag.ToString() + "/" + weapon.Model.Ammo.ToString();
        }
    }

}

