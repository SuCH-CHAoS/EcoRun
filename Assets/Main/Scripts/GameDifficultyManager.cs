using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficultyManager : MonoBehaviour
{
    public float timeToIncreaseDifficulty = 5f; // How often to increase difficulty (in seconds)
    public float timeScaleMultiplier = 0.1f; // How much to increase the time scale each time
    public float maxTimeScale = 5f; // The maximum time scale to prevent the game from getting too fast

    private float timer;

    private void Start()
    {
        timer = 0f;
        Time.timeScale = 1f; // Start the game at normal speed
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToIncreaseDifficulty)
        {
            IncreaseGameSpeed();
            timer = 0f; // Reset the timer
        }
    }

    private void IncreaseGameSpeed()
    {
        if (Time.timeScale < maxTimeScale)
        {
            Time.timeScale += timeScaleMultiplier;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 1f, maxTimeScale); // Ensure timeScale stays within bounds
            Debug.Log("Game speed increased! New Time.timeScale: " + Time.timeScale);
        }
    }
}

