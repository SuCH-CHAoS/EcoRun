using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private bool isInvincible = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartInvincibility(float duration)
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine(duration));
        }
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        isInvincible = true;
        Debug.Log("Player is now invincible!");

        // Optionally, change player appearance to indicate invincibility
        // GetComponent<Renderer>().material.color = Color.yellow;

        yield return new WaitForSeconds(duration);

        isInvincible = false;
        Debug.Log("Player is no longer invincible.");

        // Revert player appearance back to normal
        // GetComponent<Renderer>().material.color = Color.white;
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Collision logic as previously defined
    }
}
