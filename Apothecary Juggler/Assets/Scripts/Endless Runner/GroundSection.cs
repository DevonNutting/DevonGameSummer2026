using UnityEngine;

public class GroundSection : MonoBehaviour
{   
    [SerializeField] private float moveSpeed = 5f;
    private void FixedUpdate()
    {
        // Move the ground section toward the player;
        transform.position += new UnityEngine.Vector3(0, 0, -moveSpeed) * Time.deltaTime;
    }
    
}
