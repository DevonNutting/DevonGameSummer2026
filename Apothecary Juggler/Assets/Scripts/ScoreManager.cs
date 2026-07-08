using UnityEngine;
using UnityEngine.Rendering;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {get; private set;}
    [SerializeField] private int lives = 3;
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
        lives = 3; // Reset the playyer lives each play session
        // Update the UI
    }

    public void EarnPoints(int pts)
    {
        score += pts;
        // Update the UI
    }
}
