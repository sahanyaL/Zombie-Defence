/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject); // Destroy the obstacle
        }


        Destroy(gameObject);
    }
}

*/


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object hit is an obstacle (zombie)
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Trigger the shot animation
            ZombieAI zombieAI = collision.gameObject.GetComponent<ZombieAI>();
            if (zombieAI != null)
            {
                zombieAI.TriggerShot();
            }
        }

        Destroy(gameObject); // Destroy the bullet in all cases
    }
}
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;
    public float speed = 20f; // Speed at which the bullet moves

    void Awake()
    {
        // Destroy the bullet after a certain time to prevent memory leaks
        Destroy(gameObject, life);

        // Add force to the bullet in the direction it was instantiated
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * speed; // Make the bullet move forward
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object hit is an obstacle (zombie)
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Trigger the shot animation
            ZombieAI zombieAI = collision.gameObject.GetComponent<ZombieAI>();
            if (zombieAI != null)
            {
                zombieAI.TriggerShot();
            }
        }

        // Destroy the bullet after hitting any object
        Destroy(gameObject);
    }
}

