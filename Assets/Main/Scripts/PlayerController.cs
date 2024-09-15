using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Renderer playerRenderer;
    private Color originalColor;
    private bool isHighlighted = false;
    private bool canDestroyObjects = false;
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

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        if (playerRenderer != null)
        {
            originalColor = playerRenderer.material.color; // Store the original color of the player
        }
    }

    public void HighlightPlayer(Color highlightColor)
    {
        if (playerRenderer != null)
        {
            playerRenderer.material.color = highlightColor; // Change the player's color to the highlight color
            isHighlighted = true;
        }
    }

    public void RemoveHighlight()
    {
        if (playerRenderer != null && isHighlighted)
        {
            playerRenderer.material.color = originalColor; // Revert to the original color
            isHighlighted = false;
        }
    }

    public void StartInvincibility(float duration)
    {
        StartCoroutine(InvincibilityCoroutine(duration));
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        isInvincible = true;
        Debug.Log("Player is invincible!");
        // Optionally, add any visual or gameplay changes to indicate invincibility

        yield return new WaitForSeconds(duration); // Wait for the specified duration

        isInvincible = false;
        Debug.Log("Player is no longer invincible.");
        // Revert any changes made during invincibility
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }

    public void EnableObjectDestruction(float duration)
    {
        StartCoroutine(ObjectDestructionCoroutine(duration));
    }

    private IEnumerator ObjectDestructionCoroutine(float duration)
    {
        canDestroyObjects = true;
        Debug.Log("Player can destroy objects!");

        yield return new WaitForSeconds(duration);

        canDestroyObjects = false;
        Debug.Log("Player can no longer destroy objects.");
    }

    public bool CanDestroyObjects()
    {
        return canDestroyObjects;
    }
}
