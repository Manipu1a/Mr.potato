using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public GameObject explosion;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, 2);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            // ... find the Enemy script and call the Hurt function.
            collision.gameObject.GetComponent<Enemy>().Hurt();

            // Call the explosion instantiation.
            OnExplode();

            // Destroy the rocket.
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Player")
        {
            OnExplode();
            Destroy(gameObject);
        }
    }
    void OnExplode()
    {
       
            // Create a quaternion with a random rotation in the z-axis.
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Instantiate the explosion where the rocket is with the random rotation.
        Instantiate(explosion, transform.position, randomRotation);
            
    }
}
