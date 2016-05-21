using UnityEngine;
using System.Collections;

public class MyoWork : MonoBehaviour {

    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;
    public int ArmTurnState;
    void Start()
    {
        Debug.Log("Start");
    }


    void Update()
    {
        
        ThalmicHub hub = ThalmicHub.instance;
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
        //Debug.Log(thalmicMyo.gyroscope);

        if (thalmicMyo.accelerometer.x > 0.6 && thalmicMyo.accelerometer.y < 1)
        {
            transform.Find("Sword").gameObject.GetComponent<Animation>().Play("SwordRightSlash");
            Debug.Log("Right swing");
        }
        else if (thalmicMyo.accelerometer.x < -0.6 && thalmicMyo.accelerometer.y < 1)
        {
            Debug.Log("Left swing");
            transform.Find("Sword").gameObject.GetComponent<Animation>().Play("SwordLeftSlash");
        }
        else if (thalmicMyo.accelerometer.y > 1)
        {
            Debug.Log("Overhead swing");
            transform.Find("Sword").gameObject.GetComponent<Animation>().Play("AttackAnimations");
        }
        else
        {
            //Debug.Log("Nothing");
        }
        if (Input.GetKeyDown("q"))
        {
            hub.ResetHub();
        }
    }
}
