using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Projectile_Rocket : MonoBehaviour
{
    Rigidbody rocketRigidbody;
    [SerializeField] float blastRadius;

    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rocketRigidbody.AddForce(transform.forward * 25f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Untagged")
        {
            Explosion();
        }
    }

    void Explosion()
    {
        //Effect

        //Damage
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider collider in colliders)
        {
            Debug.Log(collider);
        }

        Destroy(gameObject);
    }
}
