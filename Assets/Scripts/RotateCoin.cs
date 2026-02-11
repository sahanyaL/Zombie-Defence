using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float rotationSpeed = 100f; // Rotation speed

    void Start()
    {
        // Ensure the coin is upright
        transform.rotation = Quaternion.Euler(90, 0, 0); 
    }

    void Update()
    {
        // Rotate the coin around its Z-axis (like it's flipping)
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}

