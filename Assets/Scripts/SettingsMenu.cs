using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel; // Reference to the Settings UI panel
    public Button restartButton; // Reference to the Restart button
    public Button continueButton; // Reference to the Continue button

    private void Start()
    {
        // Initially hide the Settings panel
        settingsPanel.SetActive(false);

        // Add listeners to the buttons
        restartButton.onClick.AddListener(RestartGame);
        continueButton.onClick.AddListener(ContinueGame);
    }

    // Method to show the Settings UI and pause the game
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    // Method to restart the game
    private void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the current scene
    }

    // Method to continue the game from where it was paused
    private void ContinueGame()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }
}
