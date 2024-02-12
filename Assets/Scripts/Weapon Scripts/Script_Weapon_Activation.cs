using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon_Activation : MonoBehaviour
{
    [SerializeField] SO_Weapon_Data weaponData;
    [SerializeField] Transform weaponHolder;
    [SerializeField] string muzzleSpawnerName;
    [SerializeField] Script_Weapon_Recoil weaponRecoil;
    GameObject muzzleFlashSpawner;
    Camera playerCamera;
    int currentAmmo;
    float firerate;

    float nextTimeToShoot;
    bool isReloading;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = weaponData.weaponMagazineSize;
        firerate = weaponData.weaponFirerate;

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

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToShoot && currentAmmo > 0 && !isReloading)
        {
            nextTimeToShoot = (60f / firerate) + Time.time;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit raycastHit;

        currentAmmo--;

        GameObject flash = Instantiate(weaponData.bulletModelObject, muzzleFlashSpawner.transform);
        Destroy(flash, 0.03f);

        weaponRecoil.Recoil(weaponData.weaponRecoil, weaponData.weaponRecoil, weaponData.weaponRecoil);

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out raycastHit))
        {
            Script_Enemy_Health enemyHealth = raycastHit.transform.GetComponent<Script_Enemy_Health>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(weaponData.weaponDamage);
            }
        }

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
