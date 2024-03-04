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

    [Tooltip("The audio clips that play when firing the weapon.")]
    [SerializeField] AudioClip[] firingClips;
    public AudioClip[] firingAudioClips
    {
        get
        {
            return firingClips;
        }
        private set
        {
            firingClips = value;
        }
    }

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

    [Header("Recoil Variables")]

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
    [Range(0f, 1f)] [SerializeField] float adsRecoilMultiplier;
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

    [Tooltip("How much the recoil is multiplied when moving when shooting. (Not recommended to go above 1.5)")]
    [Range(0f, 1f)] [SerializeField] float movementRecoilMultiplier;
    public float weaponMovementRecoilMultiplier
    {
        get
        {
            return movementRecoilMultiplier;
        }
        private set
        {
            movementRecoilMultiplier = value;
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

    [Tooltip("How fast the recoil resets when not firing.")]
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

    [Header("Swaying Variables")]

    [Tooltip("How much smoothing is applied on the sway when looking around.")]
    [SerializeField] float weaponSwaySmoothing;
    public float swaySmoothing
    {
        get
        {
            return weaponSwaySmoothing;
        }
        private set
        {
            weaponSwaySmoothing = value;
        }
    }

    [Tooltip("How much the step point deviates when moving the mouse.")]
    [Range(0f, 0.1f)] [SerializeField] float weaponSwayStep;
    public float swayStep
    {
        get
        {
            return weaponSwayStep;
        }
        private set
        {
            weaponSwayStep = value;
        }
    }

    [Tooltip("The max distance the weapon can sway when looking around.")]
    [SerializeField] float weaponSwayMaxStepDistance;
    public float swayMaxStepDistance
    {
        get
        {
            return weaponSwayMaxStepDistance;
        }
        private set
        {
            weaponSwayMaxStepDistance = value;
        }
    }

    [Tooltip("How much the step point deviates when moving the mouse.")]
    [SerializeField] float weaponRotationStep;
    public float rotationStep
    {
        get
        {
            return weaponRotationStep;
        }
        private set
        {
            weaponRotationStep = value;
        }
    }

    [Tooltip("The max rotation the weapon can sway when looking around.")]
    [SerializeField] float weaponSwayMaxStepRotation;
    public float swayMaxStepRotation
    {
        get
        {
            return weaponSwayMaxStepRotation;
        }
        private set
        {
            weaponSwayMaxStepRotation = value;
        }
    }

    [Header("Bob Variables")]

    [Tooltip("The max limit the weapon can bob when walking around.")]
    [SerializeField] float weaponBobTravelLimit;
    public float bobTravelLimit
    {
        get
        {
            return weaponBobTravelLimit;
        }
        private set
        {
            weaponBobTravelLimit = value;
        }
    }

    [Tooltip("The limits the weapon can bob when walking around over time.")]
    [SerializeField] float weaponBobLimit;
    public float bobLimit
    {
        get
        {
            return weaponBobLimit;
        }
        private set
        {
            weaponBobLimit = value;
        }
    }

    [Tooltip("The limits the weapon can bob when walking around over time.")]
    [SerializeField] Vector3 weaponBobMultiplier;
    public Vector3 bobMultiplier
    {
        get
        {
            return weaponBobMultiplier;
        }
        private set
        {
            weaponBobMultiplier = value;
        }
    }

    [Tooltip("The limits the weapon can bob when walking around over time.")]
    [SerializeField] float weaponbobSmoothing;
    public float bobSmoothing
    {
        get
        {
            return weaponbobSmoothing;
        }
        private set
        {
            weaponbobSmoothing = value;
        }
    }

    [Tooltip("The limits the weapon can bob when walking around over time.")]
    [SerializeField] float weaponbobSmoothingRotation;
    public float bobSmoothingRotation
    {
        get
        {
            return weaponbobSmoothingRotation;
        }
        private set
        {
            weaponbobSmoothingRotation = value;
        }
    }
}
