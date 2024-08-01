using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SkipCutscene : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    public double[] skipTimes = {6.0, 12.0, 14.0, 16.0}; // Lista cu timpii de skip
    private int currentSkipIndex = 0; // Indexul curent al timpului de skip

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SkipToNextTime();
        }
    }

    void SkipToNextTime()
    {
        if (timelineDirector != null && skipTimes.Length > 0)
        {
            timelineDirector.time = skipTimes[currentSkipIndex];
            timelineDirector.Evaluate();

            // Incrementăm indexul pentru următorul skip
            currentSkipIndex = (currentSkipIndex + 1) % skipTimes.Length;
        }
    }
}
