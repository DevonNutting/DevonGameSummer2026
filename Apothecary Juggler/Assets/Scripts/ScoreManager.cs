using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {get; private set;}
    [SerializeField] private int maxLives = 10;
    [SerializeField] private int lives;
    [SerializeField] private int score = 0;


    private void Awake()
    {
        // Check Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        score = 0; // Reset the player score each play session
        lives = maxLives; // Reset the playyer lives each play session
        // Update the UI
        UIManager.Instance.InitializeLives(lives);
        UIManager.Instance.UpdateScoreUI(score);
    }

    public void EarnPoints(int pts)
    {
        score += pts;
        // Update the UI
        UIManager.Instance.UpdateScoreUI(score);
    }

    public void LoseLife(int amount)
    {
        // Subtract amount from the remaining lives
        lives -= amount;
        // Update the UI
        UIManager.Instance.UpdateLifeUI(lives);
        // Check if all lives are gone
        if (lives <= 0)
        {
            // The Gaame is over, trigger the Game Manager
            GameManager.Instance.GameOver();
        }
    }
}
