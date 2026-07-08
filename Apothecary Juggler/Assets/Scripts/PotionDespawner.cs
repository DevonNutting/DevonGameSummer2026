using UnityEngine;

public class PotionDespawner : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Juggleable juggleable = other.gameObject.GetComponent<Juggleable>();

        if (juggleable != null)
        {
            // Despawn the juggleable
            Destroy(other.gameObject);
            // Decrement player lives
            Debug.Log($"We dropped {other.gameObject.name}!");
        }
    }
}
