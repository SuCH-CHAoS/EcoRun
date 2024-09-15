using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public GameObject gameOverUI; // Reference to the Game Over screen UI

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DangerousObject"))
        {
            if (PlayerController.instance.CanDestroyObjects())
            {
                // Destroy the object if the player can destroy objects
                Destroy(other.gameObject);
                Debug.Log("Dangerous object destroyed!");
            }
            else if (!PlayerController.instance.IsInvincible())
            {
                // Show the game over screen if the player is not invincible
                TriggerGameOver();
            }
            else
            {
                Debug.Log("Player is invincible. Scene loading blocked.");
            }
        }
    }

    // Method to trigger game over
    void TriggerGameOver()
    {
        Time.timeScale = 0f; // Stop the game
        gameOverUI.SetActive(true); // Display the Game Over screen
    }
}
