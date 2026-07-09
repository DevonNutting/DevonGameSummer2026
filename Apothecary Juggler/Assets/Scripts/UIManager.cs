using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}

    [SerializeField] private TextMeshProUGUI scoreText;
    private List<GameObject> lifeIcons = new();
    [SerializeField] private GameObject lifeIconPrefab;
    [SerializeField] private Transform lifeIconParent;

    // Awake() Called when this gameobject is enabled in the scene
    private void Awake()
    {
        // Check Singleton
        // If there is no other instance of this script in the scene...
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Destroy any duplicates of this script
            Destroy(gameObject);
        }
    } 

    public void InitializeLives(int maxLives)
    {
        lifeIcons.Clear();

        for (int i = 0; i < maxLives; i++)
        {
            GameObject icon = Instantiate(lifeIconPrefab, lifeIconParent);
            lifeIcons.Add(icon);
        }

        UpdateLifeUI(maxLives);
    }   

    public void UpdateScoreUI(int score)
    {
        // Update the score text object with the given score
        scoreText.text = $"Score: {score}";
    }

    public void UpdateLifeUI(int lives)
{
    for (int i = 0; i < lifeIcons.Count; i++)
    {
        lifeIcons[i].SetActive(i < lives);
    }
}
}
