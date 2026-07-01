using System;
using UnityEngine;

public class AudioManagers : MonoBehaviour
{
    // Singletonn variable
    public static AudioManagers Instance {get; private set;}

    [SerializeField, Tooltip("An array to store every sound file in the game.")]
    private Sound[] sounds;

    private void Awake()
    {
        // If there is no Audio Manager yet assigned in the game...
        if (Instance == null)
        {
            // Assign this instance of the this script as the "Instance" 
            Instance = this;
        }
        else // There is already an Audio Manager assigned in the scene
        {
            // Destroy the duplicate copy of this script
            Destroy(this);
        }

        // Prevent this object from being destroyed when reloading the scene
        DontDestroyOnLoad(gameObject);

        // Loop through all the Sound objects
        foreach (Sound s in sounds)
        {
            // Add an audio source component to this manager for this given sound object
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip; // Assign the audio source to this given sound object
            s.audioSource.volume = s.volume; // Assign the sounds volume
            s.audioSource.pitch = s.pitch; // Assign the sounds pitch
            s.audioSource.loop = s.loop; // Assign the sounds loop value
        }
    } 
}
