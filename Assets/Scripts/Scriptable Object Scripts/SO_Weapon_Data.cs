using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Data")]
public class SO_Weapon_Data : ScriptableObject
{
    public enum WeaponType { Pistol, SMG, Shotgun, Rifle, Sniper, Explosive, Special, Melee }
    [Tooltip("What type of weapon this is.")]
    [SerializeField] WeaponType weaponType;

    [SerializeField] GameObject weaponModel;
    public GameObject weaponModelObject
    {
        get
        {
            return weaponModel;
        }
        set
        {
            weaponModel = value;
        }
    }

    public enum BulletType { Hitscan, Projectile }
    [Tooltip("What type of bullet this weapon fires.")]
    [SerializeField] BulletType bulletType;

    [SerializeField] GameObject bulletModel;
    public GameObject bulletModelObject
    {
        get
        {
            return bulletModel;
        }
        set
        {
            bulletModel = value;
        }
    }

    public enum Firemode { Automatic, SemiAuto, Burst }
    [Tooltip("What type of firemode this weapon has.")]
    [SerializeField] Firemode weaponFiremode;

    public enum WeaponSlot { Primary, Secondary, Melee, Throwable }
    [Tooltip("Which weapon slot this weapon fits in.")]
    [SerializeField] WeaponSlot weaponSlot;

    public enum SpecialProperty { Piercing, Burning }
    [Tooltip("What type of special property this weapon might have.")]
    [SerializeField] SpecialProperty[] weaponSpecialProperty;

    [Tooltip("The amount of damage this weapon deals when hitting an enemy.")]
    [SerializeField] int damage;
    public int weaponDamage
    {
        get
        {
            return damage;
        }
        private set
        {
            damage = value;
        }
    }

    [Tooltip("The firerate of this weapon in RPM (Rounds Per Minute, Firerate/60).")]
    [SerializeField] float firerate;
    public float weaponFirerate
    {
        get
        {
            return firerate;
        }
        private set
        {
            firerate = value;
        }
    }

    [Tooltip("The max amount of bullets in a magazine for this weapon.")]
    [SerializeField] int magazineSize;
    public int weaponMagazineSize
    {
        get
        {
            return magazineSize;
        }
        private set
        {
            magazineSize = value;
        }
    }

    [Tooltip("The amount of seconds it takes to reload this weapon.")]
    [SerializeField] float reloadTime;
    public float weaponReloadTime
    {
        get
        {
            return reloadTime;
        }
        private set
        {
            reloadTime = value;
        }
    }

    [Tooltip("How much the weapon kicks when firing.")]
    [SerializeField] float recoil;
    public float weaponRecoil
    {
        get
        {
            return recoil;
        }
        private set
        {
            recoil = value;
        }
    }

    [Tooltip("How much the damage drops depending on distance from target")]
    [SerializeField] float damageDropoff;
    public float weaponDamageDropoff
    {
        get
        {
            return damageDropoff;
        }
        private set
        {
            damageDropoff = value;
        }
    }

    [Tooltip("How much the bullets spread when firing over time.")]
    [SerializeField] float bulletSpread;
    public float weaponBulletSpread
    {
        get
        {
            return bulletSpread;
        }
        private set
        {
            bulletSpread = value;
        }
    }
}
