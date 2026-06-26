using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Juggleable : MonoBehaviour
{
    [SerializeField] private float juggleForce = 12f;
    [SerializeField] private float gravityScale = 0.5f;

    private Rigidbody rb;
    
    private void Awake() => rb = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        rb.AddForce(
            Physics.gravity * gravityScale,
            ForceMode.Acceleration);
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

        rb.AddForce(launchDirection * juggleForce, ForceMode.Impulse);
    }
}
