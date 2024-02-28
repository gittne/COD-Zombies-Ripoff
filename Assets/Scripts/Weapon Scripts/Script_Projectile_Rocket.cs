using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Projectile_Rocket : MonoBehaviour
{
    Rigidbody rocketRigidbody;
    float time;
    [SerializeField] float explosionTimerThreshold;
    [SerializeField] float blastRadius;
    [SerializeField] float thrustForce;

    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rocketRigidbody.AddForce(transform.forward * thrustForce);

        time += Time.deltaTime;

        if (Timer(time, explosionTimerThreshold))
        {
            Explosion();
        }
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

    bool Timer(float timer, float threshold)
    {
        if (timer > threshold)
        {
            return true;
        }

        return false;
    }
}
