using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public GameObject coinPrefab; // Reference to the coin prefab
    public float speed = 0.5f; // Speed at which the zombie moves
    public float separationDistance = 0.5f; // Minimum distance between zombies
    public float separationForce = 1f; // Force used to push zombies apart
    public float coinHeight = 1f; // Fixed height for all coins

    private Animator animator;
    private bool isShot = false;
    private ZombieSpawner zombieSpawner;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Find the ZombieSpawner in the scene
        zombieSpawner = FindObjectOfType<ZombieSpawner>();

        // Ensure the player reference is assigned
        if (player == null)
        {
            Debug.LogError("Player Transform not assigned in ZombieAI script!");
        }
    }

    void Update()
    {
        if (!isShot && player != null) // Only move if not shot and player is assigned
        {
            // Calculate the direction towards the player
            Vector3 direction = player.position - transform.position;
            direction.Normalize(); // Normalize the direction to ensure consistent speed

            // Add separation steering to avoid zombies clustering together
            Vector3 separation = Vector3.zero;
            foreach (GameObject zombie in GameObject.FindGameObjectsWithTag("Obstacle"))
            {
                if (zombie != this.gameObject) // Avoid self-check
                {
                    float distance = Vector3.Distance(zombie.transform.position, transform.position);
                    if (distance < separationDistance)
                    {
                        // Calculate a vector away from the nearby zombie
                        Vector3 awayFromZombie = transform.position - zombie.transform.position;
                        separation += awayFromZombie / distance; // Weighted by distance
                    }
                }
            }

            // Apply the separation force
            direction += separation * separationForce;

            // Move the zombie towards the player with the applied separation
            transform.position += direction * speed * Time.deltaTime;

            // Optionally, rotate the zombie to face the player
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
    }

    public void TriggerShot()
    {
        if (isShot) return; // Ensure that the zombie is not already shot
        isShot = true;
        animator.SetTrigger("shot");

        // Instantiate a coin where the zombie died, with the fixed height
        if (coinPrefab != null)
        {
            Vector3 coinPosition = transform.position;
            coinPosition.y = coinHeight; // Set the y-coordinate to the fixed height
            Instantiate(coinPrefab, coinPosition, Quaternion.identity);
        }

        // Destroy the zombie after the animation length
        Destroy(gameObject, 2f); // Adjust the time to match your animation length

        // Notify the spawner that this zombie is dead
        if (zombieSpawner != null)
        {
            zombieSpawner.OnZombieDeath(gameObject);
        }
    }
}
