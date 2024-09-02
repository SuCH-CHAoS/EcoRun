using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
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
                // Reset the "Main" scene if the player is not invincible
                SceneManager.LoadScene("Main");
            }
            else
            {
                Debug.Log("Player is invincible. Scene loading blocked.");
            }
        }
    }
}
