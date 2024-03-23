using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy_Hitboxes : MonoBehaviour
{
    public enum BodyPart { Head, Body, Limb }
    public BodyPart bodyPart;
    [SerializeField] int bodypartHealth;
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
                bodypartHealth -= damage * 2;
                break;
            case BodyPart.Body:
                enemyHealth.enemyHealth -= damage;
                bodypartHealth -= damage;
                break;
            case BodyPart.Limb:
                enemyHealth.enemyHealth -= Mathf.RoundToInt(damage * 0.65f);
                bodypartHealth -= damage;
                break;
            default:
                break;
        }

        if (bodypartHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
