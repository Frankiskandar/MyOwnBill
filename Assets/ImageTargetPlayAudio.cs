using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetPlayAudio : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        //Debug.Log("ImageTargetPlayAudio start() gets called");
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        //Debug.Log("OnTrackableStateChanged called");
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            //Debug.Log("dollar tracked, audio should play now");
            // Play audio when target is found
            GetComponentInChildren<AudioSource>().Play();
        }
        else
        {
           // Debug.Log("dollar untracked, audio should not play");
            // Stop audio when target is lost
            GetComponentInChildren<AudioSource>().Stop();
        }
    }
}