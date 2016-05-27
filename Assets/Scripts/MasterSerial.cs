using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class MasterSerial : MonoBehaviour
{

    public static string set_serial_port = "COM5";
    public SerialPort serial = new SerialPort(set_serial_port, 9600);
    //	Debug.Log("Initalized serial port");
    private bool lightState = false;

    //public GameObject light = null;
    public AudioClip clip;

    int wheel_time = 0;


    void Start()
    {
        serial.Open();
        //serial.Write ("Testing");

        OpenCheck();
    }

    void OpenCheck()
    {
        if (serial.IsOpen == false)
        {
            //serial.Write ("Force Open");
            Debug.Log("Force Open");
            serial.Open();
        }
        else
        {
            //serial.Write ("Port already opened");
            Debug.Log("Port already opened");
        }
    }

    public void ActivateFeedback()
    {
        Debug.Log("Collision called");

        OpenCheck();
        Debug.Log("Serial sent to Arduino");
        serial.Write("1");

    }


}