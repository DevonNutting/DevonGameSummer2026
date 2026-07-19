using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(Rigidbody))]
public class Juggleable : MonoBehaviour
{
    [SerializeField] private float juggleForce = 12f;
    [SerializeField] private float gravityScale = 0.5f;
    [SerializeField] private int juggleValue = 10; // The points earned when juggling this object
    [SerializeField] private int shatterValue = 50; // The poitns earned when this juggleable shatters
    [SerializeField, Tooltip("The number of collisions/bounces before this juggleable breaks")] 
    private int integrity = 3; 

    private Rigidbody rb;
    
    private void Awake() => rb = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        rb.AddForce(
            Physics.gravity * gravityScale,
            ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collision)
    {   
        // Try to get the juggleable component off the colliding object
        Juggleable juggleable = collision.transform.GetComponent<Juggleable>();

        // If it was another juggleable object this hit...
        if(juggleable != null)
        {
            // Decrement the integrity of this juggleable and its colliding one
            Collision();
            juggleable.Collision();
            //Debug.Log($"{gameObject.name} collided with {juggleable.name}");
        }
    }

    // Logic for when a juggles collides with another or is juggled by the player
    private void Collision()
    {
        // Play Audio
        AudioManager.Instance.PlaySound("Bottle-Juggle");
        // Earn points for juggling
        ScoreManager.Instance.EarnPoints(juggleValue);
        // Decrement the integrity
        integrity -= 1;
        // Destroy this object if its integrity reaches zero
        if (integrity <= 0)
        {
            Destroy(gameObject); // Destroy this juggleable
            ScoreManager.Instance.EarnPoints(shatterValue); // Earn points for shattering the juggleable
        }
    }

    public void Juggle(Vector3 hitPoint)
    {
        Vector3 velocity = rb.linearVelocity;

        if (velocity.y < 0) velocity.y = 0;

        rb.linearVelocity = velocity;

        // Direction from the click toward the center of the bottle
        Vector3 launchDirection = transform.position - hitPoint;

        // Ignore any vertical difference
        launchDirection.y = 0f;

        // Give it an upward bias
        launchDirection = launchDirection.normalized + Vector3.up * 3f;
        launchDirection.Normalize();
        // Apply the physics forces
        rb.AddForce(launchDirection * juggleForce, ForceMode.Impulse);
        // Call the Collision logic
        Collision();
    }
}
