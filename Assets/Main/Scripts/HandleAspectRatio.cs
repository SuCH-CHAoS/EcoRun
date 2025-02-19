using UnityEngine;

public class CameraAspectRatio : MonoBehaviour
{
    // Default field of view for 16:9 aspect ratio
    private float defaultFOV = 60f;

    void Start()
    {
        AdjustCameraToAspectRatio();
    }

    void AdjustCameraToAspectRatio()
    {
        // Calculate the aspect ratio (width / height)
        float aspectRatio = (float)Screen.width / Screen.height;

        // Adjust field of view based on aspect ratio
        if (aspectRatio > 1.77f) // 16:9 or wider screens
        {
            Camera.main.fieldOfView = defaultFOV; // Default FOV for widescreens
        }
        else if (aspectRatio < 1.33f) // Narrow screens (4:3 or similar)
        {
            Camera.main.fieldOfView = defaultFOV + 10f; // Increase FOV for narrow screens
        }
        else
        {
            Camera.main.fieldOfView = defaultFOV; // Default for standard 16:9
        }

        Debug.Log("Aspect Ratio: " + aspectRatio);
    }
}
