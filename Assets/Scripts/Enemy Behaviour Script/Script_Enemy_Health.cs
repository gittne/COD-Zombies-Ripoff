using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy_Health : MonoBehaviour
{
    [SerializeField] int health;
    public int enemyHealth
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    [SerializeField] List<Script_Enemy_Hitboxes> hitboxes;

    private void Update()
    {
        //Debug.Log("The current health is: " + enemyHealth);
        HealthCheck();
    }

    public void HealthCheck()
    {
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
