/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public float MoveSpeed = 3f;
    public float smoothRotationTime = 0.12f;
    public bool enabledMobiledInputs = false;

    float currentVelocity;
    float currentSpeed;
    float speedVelocity;

    Transform cameraTransform;
    public FixedJoystick joystick;

    // Add reference to the HealthBar script
    public HealthBar healthBar;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector2 input = Vector2.zero;
        if (enabledMobiledInputs)
        {
            input = new Vector2(joystick.input.x, joystick.input.y);
        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smoothRotationTime);
        }

        float targetSpeed = MoveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, 0.1f);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
    }

    // Detect collision with zombies and take damage
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // Assuming zombies are tagged as "Obstacle"
        {
            healthBar.TakeDamage(1); // Reduce health by 1 when colliding with a zombie
        }
    }

    // Detect trigger collisions with power-ups
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power"))
        {
            healthBar.AddHealth(5); // Increase health by 5 when colliding with a power-up
            Destroy(other.gameObject); // Destroy the power-up object
        }
    }
}
*/

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public float MoveSpeed = 3f;
    public float smoothRotationTime = 0.12f;
    public bool enabledMobiledInputs = false;

    float currentVelocity;
    float currentSpeed;
    float speedVelocity;

    Transform cameraTransform;
    public FixedJoystick joystick;

    // Add reference to the HealthBar script
    public HealthBar healthBar;

    // Animator reference
    private Animator animator;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        animator = GetComponent<Animator>(); // Ensure the Animator component is attached
    }

    void Update()
    {
        Vector2 input = Vector2.zero;
        if (enabledMobiledInputs)
        {
            input = new Vector2(joystick.input.x, joystick.input.y);
        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smoothRotationTime);
        }

        float targetSpeed = MoveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, 0.1f);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        // Update the running animation
        animator.SetBool("running", inputDir != Vector2.zero);

        // Check if the space button is pressed to shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // Method to handle shooting (public so it can be called from the UI button)
    public void Shoot()
    {
        // Trigger the shooting animation
        animator.SetTrigger("fire");
        Debug.Log("Player is shooting");
        // Example: Instantiate bullet, play animation, etc.
    }

    // Detect collision with zombies and take damage
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // Assuming zombies are tagged as "Obstacle"
        {
            healthBar.TakeDamage(1); // Reduce health by 1 when colliding with a zombie
        }
    }

    // Detect trigger collisions with power-ups
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power"))
        {
            healthBar.AddHealth(5); // Increase health by 5 when colliding with a power-up
            Destroy(other.gameObject); // Destroy the power-up object
        }
    }
}
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public float MoveSpeed = 3f;
    public float smoothRotationTime = 0.12f;
    public bool enabledMobiledInputs = false;

    float currentVelocity;
    float currentSpeed;
    float speedVelocity;

    Transform cameraTransform;
    public FixedJoystick joystick;

    // Add reference to the HealthBar script
    public HealthBar healthBar;

    // Animator reference
    private Animator animator;

    // Bullet prefab and spawn point
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        animator = GetComponent<Animator>(); // Ensure the Animator component is attached
    }

    void Update()
    {
        Vector2 input = Vector2.zero;
        if (enabledMobiledInputs)
        {
            input = new Vector2(joystick.input.x, joystick.input.y);
        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smoothRotationTime);
        }

        float targetSpeed = MoveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, 0.1f);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        // Update the running animation
        animator.SetBool("running", inputDir != Vector2.zero);

        // Check if the space button is pressed to shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // Method to handle shooting (public so it can be called from the UI button)
    public void Shoot()
    {
        // Trigger the shooting animation
        animator.SetTrigger("fire");
        Debug.Log("Player is shooting");

        // Instantiate a bullet
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }

    // Detect collision with zombies and take damage
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // Assuming zombies are tagged as "Obstacle"
        {
            healthBar.TakeDamage(1); // Reduce health by 1 when colliding with a zombie
        }
    }

    // Detect trigger collisions with power-ups
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power"))
        {
            healthBar.AddHealth(5); // Increase health by 5 when colliding with a power-up
            Destroy(other.gameObject); // Destroy the power-up object
        }
    }
}
