using UnityEngine;
using System.Collections;
//using System.IO.Ports;

public class PlayerCollision : MonoBehaviour {

	public MasterSerial serialcall;
	public GameObject SerialObject;
	//public SerialPort serial = new SerialPort("COM7", 9600);
	
	void Start()
	{
		GameObject SerialObject = GameObject.Find ("MasterObject");
		serialcall = SerialObject.GetComponent <MasterSerial> ();


	}
	
	void OnCollisionStay (Collision target) {

		Debug.Log ("CollisionStay");
		if (target.transform.gameObject.name == "Player(Clone)") {
		//if (target.transform.gameObject.name == "Sword") {
			Debug.Log ("Successful collision with cube");
			serialcall.ActivateFeedback ();
		} else {
			serialcall.serial.Write("0");
			Debug.Log ("No collision except plane");
		}

	}
}
