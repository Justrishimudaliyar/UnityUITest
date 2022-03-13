using UnityEngine;

public class Model_Weapon
{
    public Model_Weapon(SO_Weapon weaponSO)
    {
        Type = weaponSO.type;
        Ammo = weaponSO.ammo;
        MagazineSize = weaponSO.magazineSize;
        FireRate = weaponSO.fireRate;
        Damage = weaponSO.damage;
        WeaponSprite = weaponSO.weaponSprite;
        AmmoInMag = MagazineSize;
        weaponSO.slotType = SlotType_Weapon.None;
        SlotType = weaponSO.slotType;
    }

    public Type_Weapon Type { get; }
    public int Ammo { get; set; }
    public int MagazineSize { get; }
    public int FireRate { get; }
    public int Damage { get; }
    public Sprite WeaponSprite { get; }
    public int AmmoInMag { get; set; }
    public SlotType_Weapon SlotType { get; set; }
}
