using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables; // Required for accessing PlayableDirector

public class Game : MonoBehaviour
{
    public PlayableDirector timeline; // Reference to the PlayableDirector component

    void Start()
    {
        // Subscribe to the stopped event when the timeline finishes playing
        if (timeline != null)
        {
            timeline.stopped += OnTimelineFinished;
        }
    }

    // Method called when the timeline finishes
    void OnTimelineFinished(PlayableDirector pd)
    {
        if (pd == timeline)
        {
            SceneManager.LoadScene("Main");
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the stopped event to prevent memory leaks
        if (timeline != null)
        {
            timeline.stopped -= OnTimelineFinished;
        }
    }
}
