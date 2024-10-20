using UnityEngine;
using UnityEngine.SceneManagement;

public class game : MonoBehaviour
{

    // This method will be called when the Main Menu button is pressed
    public void GoToMain()
    {
        SceneManager.LoadScene("Main"); 
    }
}
