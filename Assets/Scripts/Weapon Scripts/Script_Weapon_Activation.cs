using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon_Activation : MonoBehaviour
{
    [SerializeField] SO_Weapon_Data weaponData;
    Camera playerCamera;
    int currentAmmo;
    float firerate;

    float nextTimeToShoot;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = weaponData.weaponMagazineSize;
        firerate = weaponData.weaponFirerate;

        playerCamera = GetComponent<Camera>();

        Debug.Log("You have " + weaponData.weaponMagazineSize + " bullets");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToShoot)
        {
            nextTimeToShoot = (60 / firerate) + Time.time;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit raycastHit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out raycastHit))
        {
            Debug.Log("You hit: " + raycastHit.transform.name);

            Script_Enemy_Health enemyHealth = raycastHit.transform.GetComponent<Script_Enemy_Health>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(weaponData.weaponDamage);
            }
        }
    }
}
