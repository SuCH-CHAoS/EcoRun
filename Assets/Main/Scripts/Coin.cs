using UnityEngine;

public class Coin : MonoBehaviour
{
    private Score ScoreText;
    private SoundEffectManager soundEffectManager; // Reference to the SoundEffectManager

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Score>();

        soundEffectManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundEffectManager>();

    }

    private void Update()
    {
        gameObject.transform.Rotate(0, 0, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreText.ScorePlusOne();
            ProgressBar.instance.CollectCoin();

            // Play coin sound effect
            if (soundEffectManager != null)
            {
                soundEffectManager.PlayCoinSound();
            }

            Destroy(gameObject); // Destroy the coin after collection
        }
    }
}
