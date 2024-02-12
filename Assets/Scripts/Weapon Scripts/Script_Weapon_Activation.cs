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

    GameObject muzzleFlashSpawner;
    Camera playerCamera;
    int currentAmmo;

    float nextTimeToShoot;
    bool isReloading;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = weaponData.weaponMagazineSize;

        Instantiate(weaponData.weaponModelObject, weaponHolder);

        muzzleFlashSpawner = GameObject.Find(muzzleSpawnerName);

        playerCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo < weaponData.weaponMagazineSize && Input.GetButtonDown("Reload"))
        {
            StartCoroutine(Reloading(weaponData.weaponReloadTime));
        }

        if (weaponData.weaponFiremode == SO_Weapon_Data.Firemode.Automatic)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToShoot && currentAmmo > 0 && !isReloading)
            {
                nextTimeToShoot = (60f / weaponData.weaponFirerate) + Time.time;
                Shoot();
            }
        }

        if (weaponData.weaponFiremode == SO_Weapon_Data.Firemode.SemiAuto)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToShoot && currentAmmo > 0 && !isReloading)
            {
                nextTimeToShoot = (60f / weaponData.weaponFirerate) + Time.time;
                Shoot();
            }
        }

        cameraRecoil.ResetView(weaponData.weaponSnapBack, weaponData.weaponRecoilReturnSpeed);

        weaponRecoil.ResetView(weaponData.weaponSnapBack, weaponData.weaponRecoilReturnSpeed);
    }

    void Shoot()
    {
        currentAmmo--;

        GameObject flash = Instantiate(weaponData.bulletModelObject, muzzleFlashSpawner.transform);
        Destroy(flash, 0.03f);

        RaycastHit raycastHit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out raycastHit))
        {
            Script_Enemy_Health enemyHealth = raycastHit.transform.GetComponent<Script_Enemy_Health>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(weaponData.weaponDamage);
            }
        }

        cameraRecoil.Recoil(weaponData.weaponRecoilX, weaponData.weaponRecoilY, weaponData.weaponRecoilZ);
        weaponRecoil.Recoil(weaponData.weaponRecoilX / 2.5f, weaponData.weaponRecoilY / 2.5f, weaponData.weaponRecoilZ / 2.5f);

        Debug.Log("You have " + currentAmmo + " bullets");
    }

    IEnumerator Reloading(float reloadTime)
    {
        Debug.Log("Reloading...");

        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = weaponData.weaponMagazineSize;

        isReloading = false;

        Debug.Log("Finished reloading");
    }
}
