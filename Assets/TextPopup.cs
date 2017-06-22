using UnityEngine;
using System.Collections;
using Vuforia;

public class TextPopup : MonoBehaviour, ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;
    public GUIStyle tooltipStyle;
    public string labelText = "Vote for me!";

    private bool mShowGUILabel = false;
    private Rect mLabelRect = new Rect(Screen.width/2, (Screen.height/2)*1.5f , 120, 60);

    void Start()
    {
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
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            mShowGUILabel = true;
            //OnGUI(); //ERROR
        }
        else
        {
            mShowGUILabel = false;
            //OnGUI();
        }
    }

    void OnGUI()
    {
        if (mShowGUILabel)
        {
            // draw the GUI label
            GUI.Label(mLabelRect, labelText, tooltipStyle);
        }
    }
}
