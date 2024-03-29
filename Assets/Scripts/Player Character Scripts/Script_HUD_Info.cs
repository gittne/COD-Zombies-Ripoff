using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Script_HUD_Info : MonoBehaviour
{
    [SerializeField] Script_Weapon_Activation currentWeapon;
    [SerializeField] Script_Player_Stats currentPlayerStats;
    int maxHealth;

    [Header("Ammo Statistics Variables")]
    [SerializeField] TextMeshProUGUI ammoCounter;
    [SerializeField] TextMeshProUGUI maxAmmoCounter;

    [Header("Player Statistics Variables")]
    [SerializeField] Slider healthBar;
    [SerializeField] Slider staminaBar;

    [SerializeField] RawImage hitmarker;

    private void Start()
    {
        maxHealth = currentPlayerStats.characterHealth;
        hitmarker.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ShowCurrentPlayerStats(healthBar, currentPlayerStats.characterHealth, maxHealth, staminaBar, currentPlayerStats.characterStamina, currentPlayerStats.characterMaxStamina);

        ShowCurrentAmmo(currentWeapon.currentAmmo, currentWeapon.currentWeaponData.weaponMagazineSize);

        ActivateHitmarker(currentWeapon.isHitmarkerActive);
    }

    void ShowCurrentAmmo(int ammoInMag, int reserveAmmo)
    {
        ammoCounter.text = ammoInMag.ToString();
        maxAmmoCounter.text = reserveAmmo.ToString();
    }

    void ShowCurrentPlayerStats(Slider healthBar, int playerHealth, int playerMaxHealth, Slider staminaBar, float playerStamina, float playerMaxStamina)
    {
        healthBar.value = playerHealth / playerMaxHealth;

        staminaBar.value = playerStamina / playerMaxStamina;
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
