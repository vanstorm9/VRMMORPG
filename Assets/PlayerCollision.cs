using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	public MasterSerial serialcall;
	public GameObject SerialObject;
	
	void Start()
	{
		GameObject SerialObject = GameObject.Find ("MasterObject");
		serialcall = SerialObject.GetComponent <MasterSerial> ();
	}
	
	void OnCollisionEnter (Collision target) {
		Debug.Log ("Successful collision with cube");
		
		serialcall.ActivateFeedback ();
	}
}
