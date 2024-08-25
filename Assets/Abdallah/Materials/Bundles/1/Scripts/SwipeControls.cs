using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    #region Instance
    private static SwipeControls instance;
    public static SwipeControls Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SwipeControls>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned SwipeControls", typeof(SwipeControls)).GetComponent<SwipeControls>();
                }
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    public bool swipeLeft, swipeRight;

    #region public properties
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    #endregion

    private void LateUpdate()
    {
        // Reset swipe directions each frame
        swipeLeft = swipeRight = false;

        // Update keyboard input
        UpdateKeyboardInput();
    }

    public void UpdateKeyboardInput()
    {
        // Check if the A key is pressed (left swipe)
        if (Input.GetKeyDown(KeyCode.A))
        {
            swipeLeft = true;
            Debug.Log("Swiped Left (A Key)");
        }

        // Check if the D key is pressed (right swipe)
        if (Input.GetKeyDown(KeyCode.D))
        {
            swipeRight = true;
            Debug.Log("Swiped Right (D Key)");
        }
    }
}
