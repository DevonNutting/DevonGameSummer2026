using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target; // Stores the target of this enemy
    [SerializeField] private NavMeshAgent agent; // Stores the NavMeshAgent component of the enemy

    private void Awake()
    {
        // Initialize the agent variable
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Check if the enemy has a target to follow
        if (target != null)
        {
            // Follow the target
            agent.SetDestination(target.position);
        }
    } 

    // This function is called when this enemy collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // Attempt to store the Playercontroller component from the collided object
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        // Check if the object his enemy collided is the player
        if (player != null) // If this enemy collided with the player
        {
            // Take Damage
            // Kill Player
            Debug.Log($"{gameObject.name} hit {collision.gameObject.name}!");
        }
    }
}
