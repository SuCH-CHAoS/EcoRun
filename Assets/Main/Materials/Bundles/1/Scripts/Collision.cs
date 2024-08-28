using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DangerousObject"))
        {
            if (!PlayerController.instance.IsInvincible())
            {
                SceneManager.LoadScene("Main");
            }
            else
            {
                Debug.Log("Player is invincible. Scene loading blocked.");
            }
        }
    }
}
