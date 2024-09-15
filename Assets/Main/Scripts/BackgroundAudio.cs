using UnityEngine;

public class BackgroundAudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Background music clip
    public float volume = 0.3f; // Default volume level

    private AudioSource audioSource; // Reference to the AudioSource component

    private void Awake()
    {
        // Ensure this object persists across scenes
        DontDestroyOnLoad(gameObject);

        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set up the AudioSource
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // Loop the background music
        audioSource.volume = volume; // Set initial volume
        audioSource.Play(); // Start playing the background music
    }

    // Method to change the background music volume
    public void SetVolume(float newVolume)
    {
        volume = newVolume;
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    // Method to stop the background music
    public void StopBackgroundMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
