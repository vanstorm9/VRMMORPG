using UnityEngine;
using System.Collections;

public class SwordCollision : MonoBehaviour
{

    public MasterSerial serialcall;
    public GameObject SerialObject;
    //public SerialPort serial = new SerialPort("COM5", 9600);

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

        string cmp_hit = target.transform.gameObject.name;
        if (cmp_hit == "Cube" || cmp_hit == "EnemySword")
        {
            Debug.Log("Successful sword collision with " + cmp_hit);
            serialcall.ActivateFeedback();
        }
        else
        {
            serialcall.serial.Write("0");
            Debug.Log("No collision except plane");
        }

    }
}
