using UnityEngine;

public class PotionManager : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameObject[] juggleables;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnJuggleable), spawnRate, spawnRate);
    }

    private void SpawnJuggleable()
    {   
        // Do nothing if the game is already over
        if (GameManager.isGameOver) return;

        // Pick a random spawn point
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);

        // Pick a random juggleable
        int randomJuggleIndex = Random.Range(0, juggleables.Length);

        Vector3 spawnPosition = spawnPoints[randomSpawnIndex].position;

        GameObject juggleable = Instantiate(
            juggleables[randomJuggleIndex],
            spawnPosition,
            Quaternion.identity,
            parentObject.transform
        );

        Debug.Log($"Spawning {juggleable.name} at {spawnPosition}");
    }
}