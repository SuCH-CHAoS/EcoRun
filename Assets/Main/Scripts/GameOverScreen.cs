using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public AudioClip gameOverSound; // Sound effect for game over
    private AudioSource audioSource; // AudioSource component to play the sound

    // Reference to the BackgroundAudioManager
    public BackgroundAudioManager backgroundAudioManager;

    private void Start()
    {
        // Get or add an AudioSource component to this GameObject
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Play the game over sound when the UI is initialized
        PlayGameOverSound();

        // Stop the background music
        if (backgroundAudioManager != null)
        {
            backgroundAudioManager.StopBackgroundMusic();
        }
    }

    // Method to play the game over sound
    private void PlayGameOverSound()
    {
        if (audioSource && gameOverSound)
        {
            audioSource.PlayOneShot(gameOverSound);
        }
    }

    // This method will be called when the Retry button is pressed
    public void RetryGame()
    {
        Time.timeScale = 1f; // Resume the game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // This method will be called when the Main Menu button is pressed
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Resume the game time
        SceneManager.LoadScene("MainMenu"); // Load the Main Menu scene (make sure to have a scene named "MainMenu")
    }
}
