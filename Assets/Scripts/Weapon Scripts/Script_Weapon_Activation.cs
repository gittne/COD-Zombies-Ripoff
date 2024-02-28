using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon_Activation : MonoBehaviour
{
    [SerializeField] SO_Weapon_Data weaponData;
    [SerializeField] Transform weaponHolder;
    [SerializeField] string muzzleSpawnerName;

    [SerializeField] Script_Weapon_Recoil cameraRecoil;
    [SerializeField] Script_Weapon_Recoil weaponRecoil;

    GameObject weaponModel;
    GameObject muzzleFlashSpawner;
    Camera playerCamera;
    AudioSource audioSource;

    int currentAmmo;
    float nextTimeToShoot;
    bool isReloading;
    bool isShooting;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = weaponData.weaponMagazineSize;

        weaponModel = weaponData.weaponModelObject;

        Instantiate(weaponModel, weaponHolder);

        muzzleFlashSpawner = GameObject.Find(muzzleSpawnerName);

        playerCamera = GetComponent<Camera>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo < weaponData.weaponMagazineSize && Input.GetButtonDown("Reload"))
        {
            StartCoroutine(Reloading(weaponData.weaponReloadTime));
        }

        switch (weaponData.weaponFiremode)
        {
            case SO_Weapon_Data.Firemode.Automatic:
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToShoot && currentAmmo > 0 && !isReloading)
                {
                    if (weaponData.bulletType == SO_Weapon_Data.BulletType.Hitscan)
                    {
                        nextTimeToShoot = (60f / weaponData.weaponFirerate) + Time.time;
                        HitscanFire(weaponData.weaponDamage);
                    }

                    if (weaponData.bulletType == SO_Weapon_Data.BulletType.Projectile)
                    {
                        nextTimeToShoot = (60f / weaponData.weaponFirerate) + Time.time;
                        ProjectileFire(weaponData.bulletModelObject);
                    }
                }
                break;

            case SO_Weapon_Data.Firemode.SemiAuto:
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToShoot && currentAmmo > 0 && !isReloading)
                {
                    if (weaponData.bulletType == SO_Weapon_Data.BulletType.Hitscan)
                    {
                        nextTimeToShoot = (60f / weaponData.weaponFirerate) + Time.time;
                        HitscanFire(weaponData.weaponDamage);
                    }

                    if (weaponData.bulletType == SO_Weapon_Data.BulletType.Projectile)
                    {
                        nextTimeToShoot = (60f / weaponData.weaponFirerate) + Time.time;
                        ProjectileFire(weaponData.bulletModelObject);
                    }
                }
                break;

            case SO_Weapon_Data.Firemode.Burst:
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToShoot && currentAmmo > 0 && !isReloading && !isShooting)
                {
                    if (weaponData.bulletType == SO_Weapon_Data.BulletType.Hitscan)
                    {
                        nextTimeToShoot = (60f / weaponData.weaponFirerate) + Time.time;
                        StartCoroutine(BurstFireHitscan(weaponData.weaponDamage));
                    }

                    if (weaponData.bulletType == SO_Weapon_Data.BulletType.Projectile)
                    {
                        nextTimeToShoot = (60f / weaponData.weaponFirerate) + Time.time;
                        ProjectileFire(weaponData.bulletModelObject);
                    }
                }
                break;

            default:
                break;
        }

        cameraRecoil.ResetView(weaponData.weaponSnapBack, weaponData.weaponRecoilReturnSpeed);

        weaponRecoil.ResetView(weaponData.weaponSnapBack, weaponData.weaponRecoilReturnSpeed);
    }

    void HitscanFire(int damage)
    {
        currentAmmo--;

        GameObject flash = Instantiate(weaponData.bulletModelObject, muzzleFlashSpawner.transform);
        Destroy(flash, 0.03f);

        RaycastHit raycastHit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out raycastHit))
        {
            Script_Enemy_Hitboxes enemyHitbox = raycastHit.transform.GetComponent<Script_Enemy_Hitboxes>();

            if (enemyHitbox != null)
            {
                enemyHitbox.TakeDamage(damage);
            }
        }

        cameraRecoil.Recoil(weaponData.weaponRecoilX, weaponData.weaponRecoilY, weaponData.weaponRecoilZ, weaponData.weaponMovementRecoilMultiplier);
        weaponRecoil.Recoil(weaponData.weaponRecoilX / 2.5f, weaponData.weaponRecoilY / 2.5f, weaponData.weaponRecoilZ / 2.5f, weaponData.weaponMovementRecoilMultiplier / 2.5f);

        float randomPitch = Random.Range(0.9f, 1.1f);
        audioSource.pitch = randomPitch;
        int randomAudioClip = Random.Range(0, weaponData.firingAudioClips.Length);
        audioSource.PlayOneShot(weaponData.firingAudioClips[randomAudioClip]);

        Debug.Log("You have " + currentAmmo + " bullets");
    }

    IEnumerator BurstFireHitscan(int damage)
    {
        isShooting = true;
        HitscanFire(damage);
        yield return new WaitForSeconds(60f / weaponData.weaponFirerate);
        HitscanFire(damage);
        yield return new WaitForSeconds(60f / weaponData.weaponFirerate);
        HitscanFire(damage);
        yield return new WaitForSeconds(0.25f);
        isShooting = false;
    }

    void ProjectileFire(GameObject projectile)
    {
        currentAmmo--;

        Instantiate(projectile, muzzleFlashSpawner.transform.position, playerCamera.transform.rotation);

        cameraRecoil.Recoil(weaponData.weaponRecoilX, weaponData.weaponRecoilY, weaponData.weaponRecoilZ, weaponData.weaponMovementRecoilMultiplier);
        weaponRecoil.Recoil(weaponData.weaponRecoilX / 2.5f, weaponData.weaponRecoilY / 2.5f, weaponData.weaponRecoilZ / 2.5f, weaponData.weaponMovementRecoilMultiplier / 2.5f);
    }

    IEnumerator Reloading(float reloadTime)
    {
        Debug.Log("Reloading...");

        isReloading = true;

        weaponHolder.gameObject.SetActive(false);

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = weaponData.weaponMagazineSize;

        isReloading = false;

        weaponHolder.gameObject.SetActive(true);

        Debug.Log("Finished reloading");
    }
}
