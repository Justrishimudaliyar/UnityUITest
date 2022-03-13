using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SO_Weapon : ScriptableObject
{
    public Type_Weapon type;
    public SlotType_Weapon slotType;
    public Sprite weaponSprite;
    public int ammo;
    public int magazineSize;
    public int fireRate;
    public int damage;
}
