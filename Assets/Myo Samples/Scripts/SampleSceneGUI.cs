﻿using UnityEngine;
using System.Collections;

// Draw simple instructions for sample scene.
// Check to see if a Myo armband is paired.
public class SampleSceneGUI : MonoBehaviour
{
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;
    public int ArmTurnState;

    // Draw some basic instructions.
    void OnGUI ()
    {
        GUI.skin.label.fontSize = 20;

        ThalmicHub hub = ThalmicHub.instance;

        // Access the ThalmicMyo script attached to the Myo object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
        
        if (!hub.hubInitialized) {
            GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
                "Cannot contact Myo Connect. Is Myo Connect running?\n" +
                "Press Q to try again."
            );
        } else if (!thalmicMyo.isPaired) {
            GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
                "No Myo currently paired."
            );
        } else if (!thalmicMyo.armSynced) {
            GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
                "Perform the Sync Gesture."
            );
        } else {
            GUI.Label (new Rect (12, 8, Screen.width, Screen.height),
                "Myo connected"
            );
        }
    }

    void Update ()
    {
        ThalmicHub hub = ThalmicHub.instance;
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
        //Debug.Log(thalmicMyo.gyroscope);

        if (thalmicMyo.gyroscope.x > 45)
            Debug.Log("Right swing");
        else if (thalmicMyo.gyroscope.x < 0)
            Debug.Log("Left swing");
        else
            Debug.Log("Neutral");
                
        if (Input.GetKeyDown ("q")) {
            hub.ResetHub();
        }
    }
}
