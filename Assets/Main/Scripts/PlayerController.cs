using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private bool isInvincible = false;
    private bool canDestroyObjects = false;

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
        StartCoroutine(InvincibilityCoroutine(duration));
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        isInvincible = true;
        Debug.Log("Player is now invincible!");

        yield return new WaitForSeconds(duration);

        isInvincible = false;
        Debug.Log("Player is no longer invincible.");
    }

    public void EnableObjectDestruction(float duration)
    {
        StartCoroutine(ObjectDestructionCoroutine(duration));
    }

    private IEnumerator ObjectDestructionCoroutine(float duration)
    {
        canDestroyObjects = true;
        Debug.Log("Player can now destroy dangerous objects!");

        yield return new WaitForSeconds(duration);

        canDestroyObjects = false;
        Debug.Log("Player can no longer destroy objects.");
    }

    public bool CanDestroyObjects()
    {
        return canDestroyObjects;
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }
}
