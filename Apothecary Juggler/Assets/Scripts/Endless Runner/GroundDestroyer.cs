using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GroundSection ground = other.GetComponent<GroundSection>();

        if (ground != null)
        {
            Destroy(other.gameObject);
        }
    }
}
