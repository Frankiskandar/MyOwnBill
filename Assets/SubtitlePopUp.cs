using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using Vuforia;

public class SubtitlePopUp : MonoBehaviour,  ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;
    private GameObject background_obj;
    private GameObject subtitle_obj;
    string text = "Hello my name is Barrack Obama \n don't forget to vote!";

	// Use this for initialization
	void Start () {

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        background_obj = GameObject.Find("background");
        subtitle_obj = GameObject.Find("subtitle");

        //set default states of UI 
        background_obj.SetActive(false);
        background_obj.transform.parent.gameObject.SetActive(false);
        subtitle_obj.SetActive(false);
        subtitle_obj.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            // if image target is being tracked
            ShowSubtitle(text);
        }
        else
        {
            HideSubtitle();
        }
    }

    public void ShowSubtitle (string text)
    {

        //enable UI
        background_obj.SetActive(true);
        background_obj.transform.parent.gameObject.SetActive(true);
        subtitle_obj.SetActive(true);
        subtitle_obj.transform.parent.gameObject.SetActive(true);

        subtitle_obj.GetComponent<Text>().text = text;
    }

    public void HideSubtitle ()
    {
        //disable UI
        if (background_obj != null) {
            background_obj.SetActive(false);
            background_obj.transform.parent.gameObject.SetActive(false);
        }

        if (subtitle_obj != null)
        {
            subtitle_obj.SetActive(false);
            subtitle_obj.transform.parent.gameObject.SetActive(false);
        }



    }
}
