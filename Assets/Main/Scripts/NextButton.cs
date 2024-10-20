using UnityEngine;
using UnityEngine.UI; // Required for accessing UI components like Button

public class ToggleGameObjects : MonoBehaviour
{
    public GameObject[] gameObjects; // Array of GameObjects to toggle between
    public Button nextButton; // Reference to the Next button

    private int currentIndex = 0; // To keep track of the current GameObject

    void Start()
    {
        // Set up the button listener to call NextGameObject method when clicked
        nextButton.onClick.AddListener(NextGameObject);

        // Show only the first GameObject and hide the rest at the start
        UpdateGameObjects();
    }

    // This method is called when the Next button is clicked
    public void NextGameObject()
    {
        // Deactivate the current GameObject
        gameObjects[currentIndex].SetActive(false);

        // Increment the index to move to the next GameObject
        currentIndex++;

        // Loop back to the first GameObject if we go beyond the last one
        if (currentIndex >= gameObjects.Length)
        {
            currentIndex = 0;
        }

        // Activate the new current GameObject
        gameObjects[currentIndex].SetActive(true);
    }

    // This method updates the visibility of the GameObjects
    private void UpdateGameObjects()
    {
        // Loop through the GameObjects and only keep the current one active
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(i == currentIndex);
        }
    }
}
