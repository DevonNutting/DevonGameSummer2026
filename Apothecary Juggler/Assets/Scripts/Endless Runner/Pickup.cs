using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private int pointValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        // Try to grab the player's PlayerController component
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        // Check if the colliding object is the player
        if (player != null)
        {
            // Earn Points 
            Debug.Log($"Player earned {pointValue} points!");
            // Destroy this pickup
            Destroy(gameObject);
        }
    }
}
