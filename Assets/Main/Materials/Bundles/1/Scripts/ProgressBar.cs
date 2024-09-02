using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar instance;

    public Image progressBar; // The UI Image representing the progress bar
    private int coinsCollected = 0;
    private int totalCoins = 10;

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

    public void CollectCoin()
    {
        coinsCollected++;
        coinsCollected = Mathf.Clamp(coinsCollected, 0, totalCoins);

        // Update the progress bar fill
        if (progressBar != null)
        {
            progressBar.fillAmount = (float)coinsCollected / totalCoins;
        }

        // Trigger the event when the player collects 10 coins
        if (coinsCollected == 10)
        {
            OnCollectTenCoins();
        }

        // Trigger the event when the bar is full
        if (coinsCollected == totalCoins)
        {
            OnProgressBarFull();
        }
    }

    private void OnCollectTenCoins()
    {
        Debug.Log("10 coins collected! Player is invincible for 5 seconds.");
        PlayerController.instance.StartInvincibility(5f); // Correctly pass duration for invincibility
    }

    private void OnProgressBarFull()
    {
        Debug.Log("Progress bar is full! Player can destroy dangerous objects.");
        PlayerController.instance.EnableObjectDestruction(5f); // Enable object destruction for 5 seconds

        StartCoroutine(ResetProgressBar());
    }

    private IEnumerator ResetProgressBar()
    {
        yield return new WaitForSeconds(5f);

        coinsCollected = 0;

        if (progressBar != null)
        {
            progressBar.fillAmount = 0;
        }

        Debug.Log("Progress bar has been reset.");
    }
}
