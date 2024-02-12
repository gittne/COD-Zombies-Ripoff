using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Data")]
public class SO_Weapon_Data : ScriptableObject
{
    public enum WeaponType { Pistol, SMG, Shotgun, Rifle, Sniper, Explosive, Special, Melee }
    [Tooltip("What type of weapon this is.")]
    public WeaponType weaponType;

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
    public BulletType bulletType;

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
    public Firemode weaponFiremode;

    public enum WeaponSlot { Primary, Secondary, Melee, Throwable }
    [Tooltip("Which weapon slot this weapon fits in.")]
    public WeaponSlot weaponSlot;

    public enum SpecialProperty { Piercing, Burning }
    [Tooltip("What type of special property this weapon might have.")]
    public SpecialProperty[] weaponSpecialProperty;

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

    [Tooltip("How much the weapon rotates around the X-axis when firing.")]
    [SerializeField] float xRecoil;
    public float weaponRecoilX
    {
        get
        {
            return xRecoil;
        }
        private set
        {
            xRecoil = value;
        }
    }

    [Tooltip("How much the weapon rotates around the Y-axis when firing.")]
    [SerializeField] float yRecoil;
    public float weaponRecoilY
    {
        get
        {
            return yRecoil;
        }
        private set
        {
            yRecoil = value;
        }
    }

    [Tooltip("How much the weapon rotates around the Z-axis when firing.")]
    [SerializeField] float zRecoil;
    public float weaponRecoilZ
    {
        get
        {
            return zRecoil;
        }
        private set
        {
            zRecoil = value;
        }
    }

    [Tooltip("How much the recoil is multiplied when ADS'ing.")]
    [SerializeField] float adsRecoilMultiplier;
    public float weaponAdsRecoilMultiplier
    {
        get
        {
            return adsRecoilMultiplier;
        }
        private set
        {
            adsRecoilMultiplier = value;
        }
    }

    [Tooltip("How much the weapon recoil snaps when shooting.")]
    [SerializeField] float recoilSnappiness;
    public float weaponSnapBack
    {
        get
        {
            return recoilSnappiness;
        }
        private set
        {
            recoilSnappiness = value;
        }
    }

    [Tooltip("How much fast the recoil resets when not firing.")]
    [SerializeField] float recoilReturnSpeed;
    public float weaponRecoilReturnSpeed
    {
        get
        {
            return recoilReturnSpeed;
        }
        private set
        {
            recoilReturnSpeed = value;
        }
    }
}
