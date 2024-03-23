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

    private void Start()
    {
        HeadCheck(hitboxes);
    }

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

    void HeadCheck(List<Script_Enemy_Hitboxes> hitboxes)
    {
        foreach (Script_Enemy_Hitboxes hitbox in hitboxes)
        {
            if (hitbox.bodyPart == Script_Enemy_Hitboxes.BodyPart.Head)
            {
                Debug.Log("I have a head");
            }
        }
    }
}
