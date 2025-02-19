using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    #region Singleton Instance
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

    #region Public Properties
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    #endregion

    private Vector2 touchStartPos;
    private float swipeThreshold = 50f; // Minimum distance for a valid swipe

    private void LateUpdate()
    {
        // Reset swipe directions each frame
        swipeLeft = swipeRight = false;

        // Update touch input
        UpdateTouchInput();
    }

    private void UpdateTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    Debug.Log("Touch Started at: " + touchStartPos.x);
                    break;

                case TouchPhase.Moved:
                    Vector2 touchCurrentPos = touch.position;
                    float deltaX = touchCurrentPos.x - touchStartPos.x;

                    if (Mathf.Abs(deltaX) > swipeThreshold)
                    {
                        if (deltaX > 0)
                        {
                            swipeLeft = true; // Swiping right now moves the player **LEFT**
                            Debug.Log("Swiped Right -> Move Left");
                        }
                        else
                        {
                            swipeRight = true; // Swiping left now moves the player **RIGHT**
                            Debug.Log("Swiped Left -> Move Right");
                        }
                        // Reset touchStartPos to prevent multiple swipes in a single touch
                        touchStartPos = touchCurrentPos;
                    }
                    break;

                case TouchPhase.Ended:
                    Debug.Log("Touch Ended at: " + touch.position.x);
                    break;
            }
        }
    }
}
