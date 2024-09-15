using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioClip coinSound; // Coin collection sound clip
    public float coinSoundVolume = 3f; // Volume for coin sound effects

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

        // Set up the AudioSource for sound effects
        audioSource.volume = coinSoundVolume; // Set initial volume
    }

    // Method to play the coin sound
    public void PlayCoinSound()
    {
        if (audioSource != null && coinSound != null)
        {
            audioSource.PlayOneShot(coinSound, coinSoundVolume); // Play sound effect
        }
    }
}
