using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy_Hitboxes : MonoBehaviour
{
    public enum BodyPart { Head, Body }
    public BodyPart bodyPart;
    public int health { get; private set; }
    Script_Enemy_Health enemyHealth;

    private void Start()
    {
        enemyHealth = GetComponentInParent<Script_Enemy_Health>();
    }

    public void TakeDamage(int damage)
    {
        switch (bodyPart)
        {
            case BodyPart.Head:
                enemyHealth.enemyHealth -= damage * 2;
                break;
            case BodyPart.Body:
                enemyHealth.enemyHealth -= damage;
                break;
            default:
                break;
        }
    }
}
