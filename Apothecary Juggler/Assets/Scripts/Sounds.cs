using UnityEngine;

[System.Serializable]
public class Sounds
{
    // The name of the sound effect
    public string name;
    // The audio file attached to this sound effect
    public AudioClip audioClip;
    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(0.1f, 2f)]
    public float pitch = 1f;
    public bool loop = false;

    [HideInInspector]
    public AudioSource audioSource;

}
