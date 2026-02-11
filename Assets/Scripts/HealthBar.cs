using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    void Start()
    {
        healthSlider.value = healthSlider.maxValue; // Initialize health to max value
        SetHealthBarColor(Color.red); // Set the color to red initially
    }

    public void TakeDamage(int damage)
    {
        healthSlider.value -= damage; // Reduce health by the damage amount
        healthSlider.value = Mathf.Clamp(healthSlider.value, 0, healthSlider.maxValue); // Ensure health doesn't go below 0

        // Keep the health bar red
        SetHealthBarColor(Color.red);

        if (healthSlider.value <= 0)
        {
            GameOver(); // Trigger GameOver if health is 0
        }
    }

    public void AddHealth(int amount)
    {
        healthSlider.value += amount; // Increase health by the specified amount
        healthSlider.value = Mathf.Clamp(healthSlider.value, 0, healthSlider.maxValue); // Ensure health doesn't exceed max value

        // Keep the health bar red
        SetHealthBarColor(Color.red);
    }

    void SetHealthBarColor(Color color)
    {
        healthSlider.fillRect.GetComponentInChildren<Image>().color = color;
    }

    void GameOver()
    {
        // Instead of restarting, we trigger the GameOver in the GameManager
        GameManager.instance.TriggerGameOver();
    }
}
