using UnityEngine;
using System.Collections;

public class SwordCollision : MonoBehaviour
{

    public MasterSerial serialcall;
    public GameObject SerialObject;
    //public SerialPort serial = new SerialPort("COM7", 9600);

    void Start()
    {
        GameObject SerialObject = GameObject.Find("MasterObject");
        serialcall = SerialObject.GetComponent<MasterSerial>();


    }


    void checkCollision(GameObject subject)
    {

        if (subject.name != "Plane")
        {
            Debug.Log("Collision: " + subject.name);
        }
    }


    void OnCollisionStay(Collision target)
    {
        //Debug.Log("Suki suki Puwa Puwa");

        //checkCollision(target.transform.gameObject);

        if (target.transform.gameObject.name == "Cube")
        {
            Debug.Log("Successful sword collision with cube");
            serialcall.ActivateFeedback();
        }
        else
        {
            serialcall.serial.Write("0");
            Debug.Log("No collision except plane");
        }

    }
}
