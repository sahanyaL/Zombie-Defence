using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        // Check if the object colliding with the coin is the player
        if (other.CompareTag("Player"))
        {
            // Increase the score (we'll handle this in another script)
            GameManager.instance.IncreaseScore(1);

            // Destroy the coin to simulate collection
            Destroy(gameObject);
        }
    }
}
