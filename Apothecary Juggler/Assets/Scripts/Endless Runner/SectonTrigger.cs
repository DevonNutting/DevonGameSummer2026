using System;
using UnityEngine;

public class SectonTrigger : MonoBehaviour
{
    [SerializeField] private GameObject roadSection;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            // Spawn the next road section
            Instantiate(roadSection, new UnityEngine.Vector3(0, 0, transform.position.z + 50f), Quaternion.identity);

            // Destroy this trigger to avoid multiple triggers
            Destroy(this);
        }
    }
        
    
}
