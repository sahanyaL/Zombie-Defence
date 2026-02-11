/*using UnityEngine;
using System.Collections.Generic;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Single zombie prefab (or array if you have multiple)
    public Transform[] spawnPoints; // Array of spawn points for the zombies
    public Transform player; // Reference to the player in the scene
    public float respawnDelay = 5f; // Delay before zombies respawn

    private List<GameObject> zombies = new List<GameObject>(); // List to keep track of zombies
    private bool allZombiesDead = false;

    void Start()
    {
        SpawnZombies();
    }

    void Update()
    {
        // Check if all zombies are dead
        if (allZombiesDead)
        {
            // If all zombies are dead, start the respawn process
            Invoke("RespawnZombies", respawnDelay);
            allZombiesDead = false;
        }
    }

    public void OnZombieDeath(GameObject zombie)
    {
        Debug.Log("Zombie died: " + zombie.name);
        zombies.Remove(zombie);

        if (zombies.Count == 0)
        {
            allZombiesDead = true;
        }
    }

    void RespawnZombies()
    {
        Debug.Log("Respawning zombies...");
        zombies.Clear();
        SpawnZombies();
    }

    void SpawnZombies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
            ZombieAI zombieAI = zombie.GetComponent<ZombieAI>();

            if (zombieAI != null)
            {
                zombieAI.player = player; // Dynamically assign the player Transform
            }

            zombies.Add(zombie);
        }
    }
}
*/


/*

using UnityEngine;
using System.Collections.Generic;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Single zombie prefab
    public Transform[] spawnPoints; // Array of spawn points for the zombies
    public Transform player; // Reference to the player in the scene
    public float respawnDelay = 5f; // Delay before zombies respawn
    public GameObject[] doors; // Array of doors to manage

    private List<GameObject> zombies = new List<GameObject>(); // List to keep track of zombies
    private bool allZombiesDead = false;
    private int currentRoomIndex = 0; // To track which room we're currently in

    void Start()
    {
        SpawnZombies();
    }

    void Update()
    {
        if (allZombiesDead)
        {
            // If all zombies are dead, start the process for the next room
            if (currentRoomIndex < doors.Length)
            {
                Destroy(doors[currentRoomIndex]); // Destroy the door to the next room
                currentRoomIndex++;
            }

            // Start the respawn process or progress to the next room
            if (currentRoomIndex < spawnPoints.Length)
            {
                Invoke("RespawnZombies", respawnDelay);
            }

            allZombiesDead = false;
        }
    }

    public void OnZombieDeath(GameObject zombie)
    {
        zombies.Remove(zombie);

        if (zombies.Count == 0)
        {
            allZombiesDead = true;
        }
    }

    void RespawnZombies()
    {
        zombies.Clear();
        SpawnZombies();
    }

    void SpawnZombies()
    {
        if (currentRoomIndex < spawnPoints.Length)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
                ZombieAI zombieAI = zombie.GetComponent<ZombieAI>();

                if (zombieAI != null)
                {
                    zombieAI.player = player; // Dynamically assign the player Transform
                }

                zombies.Add(zombie);
            }
        }
    }
}

*/


using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // Include this for scene management

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Single zombie prefab
    public Transform[] spawnPoints; // Array of spawn points for the zombies
    public Transform player; // Reference to the player in the scene
    public float respawnDelay = 5f; // Delay before zombies respawn
    public GameObject[] doors; // Array of doors to manage

    private List<GameObject> zombies = new List<GameObject>(); // List to keep track of zombies
    private bool allZombiesDead = false;
    private int currentRoomIndex = 0; // To track which room we're currently in

    void Start()
    {
        SpawnZombies();
    }

    void Update()
    {
        if (allZombiesDead)
        {
            // If all zombies are dead, start the process for the next room
            if (currentRoomIndex < doors.Length)
            {
                Destroy(doors[currentRoomIndex]); // Destroy the door to the next room
                currentRoomIndex++;
            }

            // Check if all doors have been destroyed
            if (currentRoomIndex >= doors.Length)
            {
                RestartGame(); // Restart the game if all doors are destroyed
                return; // Exit the method to prevent further execution
            }

            // Start the respawn process or progress to the next room
            if (currentRoomIndex < spawnPoints.Length)
            {
                Invoke("RespawnZombies", respawnDelay);
            }

            allZombiesDead = false;
        }
    }

    public void OnZombieDeath(GameObject zombie)
    {
        zombies.Remove(zombie);

        if (zombies.Count == 0)
        {
            allZombiesDead = true;
        }
    }

    void RespawnZombies()
    {
        zombies.Clear();
        SpawnZombies();
    }

    void SpawnZombies()
    {
        if (currentRoomIndex < spawnPoints.Length)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
                ZombieAI zombieAI = zombie.GetComponent<ZombieAI>();

                if (zombieAI != null)
                {
                    zombieAI.player = player; // Dynamically assign the player Transform
                }

                zombies.Add(zombie);
            }
        }
    }

    void RestartGame()
    {
        // Restart the game by reloading the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

