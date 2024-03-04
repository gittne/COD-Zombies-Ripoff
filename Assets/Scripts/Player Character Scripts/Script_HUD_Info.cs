using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Script_HUD_Info : MonoBehaviour
{
    [SerializeField] Script_Weapon_Activation currentWeapon;
    [SerializeField] TextMeshProUGUI ammoCounter;
    [SerializeField] TextMeshProUGUI maxAmmoCounter;
    [SerializeField] RawImage hitmarker;

    private void Start()
    {
        hitmarker.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ShowCurrentAmmo(currentWeapon.currentAmmo, currentWeapon.currentWeaponData.weaponMagazineSize);

        ActivateHitmarker(currentWeapon.isHitmarkerActive);
    }

    void ShowCurrentAmmo(int ammoInMag, int reserveAmmo)
    {
        ammoCounter.text = ammoInMag.ToString();
        maxAmmoCounter.text = reserveAmmo.ToString();
    }

    void ActivateHitmarker(bool isActivated)
    {
        if (isActivated)
        {
            hitmarker.gameObject.SetActive(true);
        }
        else
        {
            hitmarker.gameObject.SetActive(false);
        }
    }
}
