using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;
    private ScoreManager scoreManager;

    public GameObject gameOverPanel; // Reference to the GameOver Panel
    public Button playAgainButton; // Reference to the Play Again button
    public Button exitButton; // Reference to the Exit button
    private bool isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        // Ensure the panel and buttons are assigned
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // Initially hide the GameOver panel

        if (playAgainButton != null)
            playAgainButton.onClick.AddListener(RestartGame);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        if (scoreManager != null)
        {
            scoreManager.IncreaseScore(amount);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void TriggerGameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true); // Show the GameOver panel

            Time.timeScale = 0f; // Pause the game
        }
    }

    private void RestartGame()
    {
        if (isGameOver)
        {
            Time.timeScale = 1f; // Resume the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the current scene
            isGameOver = false; // Reset the game over state

            if (gameOverPanel != null)
                gameOverPanel.SetActive(false); // Hide the GameOver panel
        }
    }

    private void ExitGame()
    {
        Application.Quit(); // Exit the game
    }
}


