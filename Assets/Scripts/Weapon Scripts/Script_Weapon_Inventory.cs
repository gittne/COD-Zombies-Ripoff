using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon_Inventory : MonoBehaviour
{
    [SerializeField] SO_Weapon_Data primaryWeapon;
    public SO_Weapon_Data currentPrimaryWeaponData
    {
        get
        {
            return primaryWeapon;
        }
        private set
        {
            primaryWeapon = value;
        }
    }
    [SerializeField] SO_Weapon_Data secondaryWeapon;
    public SO_Weapon_Data currentSecondaryWeaponData
    {
        get
        {
            return secondaryWeapon;
        }
        private set
        {
            secondaryWeapon = value;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
