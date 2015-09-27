using UnityEngine;
using System.Collections;

// Draw simple instructions for sample scene.
// Check to see if a Myo armband is paired.
public class SampleSceneGUI : MonoBehaviour
{
    public Component[] array_points;
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;
    public int ArmTurnState;
    public GameObject ani;
    // Draw some basic instructions.


    private bool finished = false;
    private int loaderCounter = 0;

    void Start()
    {
        StartCoroutine(StartLoader());
    }

    IEnumerator StartLoader()
    {
        //Instantiate(cube, positions[loaderCounter], Quaternion.identity);
        yield return new WaitForSeconds(10);
        
        
    }
    void OnGUI()
    {
        GUI.skin.label.fontSize = 20;

        ThalmicHub hub = ThalmicHub.instance;

        // Access the ThalmicMyo script attached to the Myo object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        if (!hub.hubInitialized) {
            GUI.Label(new Rect(12, 8, Screen.width, Screen.height),
                "Cannot contact Myo Connect. Is Myo Connect running?\n" +
                "Press Q to try again."
            );
        } else if (!thalmicMyo.isPaired) {
            GUI.Label(new Rect(12, 8, Screen.width, Screen.height),
                "No Myo currently paired."
            );
        } else if (!thalmicMyo.armSynced) {
            GUI.Label(new Rect(12, 8, Screen.width, Screen.height),
                "Perform the Sync Gesture."
            );
        } else {
            GUI.Label(new Rect(12, 8, Screen.width, Screen.height),
                "Myo connected"
            );
        }
    }

    void Update()
    {
        ThalmicHub hub = ThalmicHub.instance;
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
        //Debug.Log(thalmicMyo.gyroscope);
        GameObject player_obj = GameObject.Find("Player(Clone)");
        
        ani = player_obj.transform.Find("Sword").gameObject;
        if (player_obj != null)
        {
            Debug.Log("Good to go");
            
        }else {
            Debug.Log("Null");
        }
        


       

        if (thalmicMyo.accelerometer.x > 1.2 && thalmicMyo.accelerometer.y < 1)
        {
            Debug.Log("Right swing");

            ani.GetComponent<Animation>().Play("SwordRightSlash");
            StartLoader();
            //transform.Find("Sword").gameObject.GetComponent<Animation>().Play("SwordRightSlash");
        }
        else if (thalmicMyo.accelerometer.x < -1.2 && thalmicMyo.accelerometer.y < 1)
        {
            Debug.Log("Left swing");
            ani.GetComponent<Animation>().Play("SwordLeftSlash");
            StartLoader();
            //transform.Find("Sword").gameObject.GetComponent<Animation>().Play("SwordLeftSlash");
        } else if (thalmicMyo.accelerometer.y > 2) {
            ani.GetComponent<Animation>().Play("AttackAnimations");
            StartLoader();
            Debug.Log("Overhead swing");
        }else{
            Debug.Log("Nothing");
        }

        if (Input.GetKeyDown ("q")) {
            hub.ResetHub();
        }
    }
}
