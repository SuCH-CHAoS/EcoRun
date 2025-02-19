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
    private bool isSwiping = false;

    #region Public Properties
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    #endregion

    private Vector2 touchStartPos;
    private float swipeThreshold = 50f;

    private void LateUpdate()
    {
        // Reset swipe directions each frame
        swipeLeft = swipeRight = false;

        UpdateTouchInput();
    }

    private void UpdateTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isSwiping = false; // Reset swipe flag for new touch
                    Debug.Log("Touch Started at: " + touchStartPos.x);
                    break;

                case TouchPhase.Moved:
                    if (!isSwiping) // Only process if not already swiped
                    {
                        Vector2 touchCurrentPos = touch.position;
                        float deltaX = touchCurrentPos.x - touchStartPos.x;

                        if (Mathf.Abs(deltaX) > swipeThreshold)
                        {
                            if (deltaX > 0)
                            {
                                swipeLeft = true;
                            }
                            else
                            {
                                swipeRight = true;
                            }
                            isSwiping = true; // Prevent additional swipes
                            touchStartPos = touchCurrentPos;
                            Debug.Log("Swipe Registered: " + (swipeLeft ? "Left" : "Right"));
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isSwiping = false; // Reset for next touch
                    Debug.Log("Touch Ended");
                    break;
            }
        }
    }
}