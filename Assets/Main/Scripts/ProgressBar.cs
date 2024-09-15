using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar instance;

    public Image progressBar; // The UI Image representing the progress bar
    public Color highlightColor = Color.yellow; // Color to highlight when full
    private Color originalColor;

    private int coinsCollected = 0;
    private int totalCoins = 10; // Number of coins needed to fill the bar
    private bool isBarDecreasing = false;

    public float decreaseRate = 10f; // Speed at which the progress bar decreases over time

    private PlayerController playerController;

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
        originalColor = progressBar.color; // Store the original color of the progress bar
        playerController = PlayerController.instance;
    }

    public void CollectCoin()
    {
        if (isBarDecreasing) return; // Prevent increasing the bar if it's in the decreasing phase

        coinsCollected++;
        coinsCollected = Mathf.Clamp(coinsCollected, 0, totalCoins);

        // Update the progress bar fill
        if (progressBar != null)
        {
            progressBar.fillAmount = (float)coinsCollected / totalCoins;
        }

        // Highlight and start decreasing the bar when it's full
        if (coinsCollected == totalCoins && !isBarDecreasing)
        {
            OnProgressBarFull();
        }
    }

    private void OnProgressBarFull()
    {
        Debug.Log("Progress bar is full! Highlighting bar and player, enabling object destruction.");
        HighlightBar();
        playerController.HighlightPlayer(highlightColor); // Highlight the player
        playerController.EnableObjectDestruction(10f); // Enable object destruction for 5 seconds

        // Start the bar decreasing coroutine
        StartCoroutine(DecreaseProgressBar());
    }

    private void HighlightBar()
    {
        if (progressBar != null)
        {
            progressBar.color = highlightColor; // Change the color of the progress bar to the highlight color
        }
    }

    private void RemoveHighlight()
    {
        if (progressBar != null)
        {
            progressBar.color = originalColor; // Revert to the original color
        }
        playerController.RemoveHighlight(); // Remove highlight from the player
    }

    private IEnumerator DecreaseProgressBar()
    {
        isBarDecreasing = true; // Flag to indicate that the bar is decreasing

        while (progressBar.fillAmount > 0)
        {
            progressBar.fillAmount -= decreaseRate * Time.deltaTime; // Gradually decrease the bar
            coinsCollected = Mathf.RoundToInt(progressBar.fillAmount * totalCoins); // Update the coinsCollected value accordingly

            if (progressBar.fillAmount <= 0)
            {
                progressBar.fillAmount = 0;
                coinsCollected = 0;
                RemoveHighlight(); // Remove highlight when the progress bar is empty
                isBarDecreasing = false; // Allow coins to be collected again
            }

            yield return null;
        }

        Debug.Log("Progress bar is empty.");
    }
}
