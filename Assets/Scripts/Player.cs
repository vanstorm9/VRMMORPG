using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 6f;
	private GameObject swordObj;
	public int playerState; 
	public Camera cam;



	void Start()
	{
		//sword = GameObject.Find("Sword");
		//swordComponents = GetComponentsInChildren (sword);
	}

	void Update()
	{
		if (GetComponent<NetworkView> ().isMine) {
			InputMovement ();
			//GetComponent(Camera).enabled = true;
			InputColorChange ();
		} else {

			//GetComponent(Camera).enabled = false;
		}
		/*
		else
		{
			SyncedMovement();
		}
		*/
	}

	void OnPlayerDisconnected(NetworkPlayer player)
	{
		Network.RemoveRPCs (player);
		Network.DestroyPlayerObjects (player);
	}

	private void InputColorChange()
	{
		if (Input.GetKeyDown(KeyCode.R))
			ChangeColorTo(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
	}
	
	[RPC] void ChangeColorTo(Vector3 color)
	{
		GetComponent<Renderer>().material.color = new Color(color.x, color.y, color.z, 1f);
		
		if (GetComponent<NetworkView>().isMine)
			GetComponent<NetworkView>().RPC("ChangeColorTo", RPCMode.OthersBuffered, color);
	}
	
	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		GetComponent<Rigidbody>().position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}
	
	
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;
	/*
	void OppositeAnimationState(int aniState)
	{
		if (aniState == 2) 
		{
			transform.Find("Sword").gameObject.GetComponent<Animation>().Play("AttackAnimations");
		}

	}
	*/
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;
		if (stream.isWriting)
		{
			syncPosition = GetComponent<Rigidbody>().position;
			stream.Serialize(ref syncPosition);
			
			syncVelocity = GetComponent<Rigidbody>().velocity;
			stream.Serialize(ref syncVelocity);

			//OppositeAnimationState(playerState);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncVelocity);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = GetComponent<Rigidbody>().position;
		}
	}
	
	
	void InputMovement()
	{
		if (Input.GetKey(KeyCode.W))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * speed * Time.deltaTime);
			
		if (Input.GetKey(KeyCode.S))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - transform.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.D))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.right * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.A))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - transform.right * speed * Time.deltaTime);
		if (Input.GetKey(KeyCode.E))
			transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
		if (Input.GetKey(KeyCode.Q))
			transform.RotateAround(transform.position, transform.up, Time.deltaTime * -90f);

		if (Input.GetKey (KeyCode.O))
			//swordObj = transform.Find("Sword").gameObject;
			//playerState = 2;
			transform.Find("Sword").gameObject.GetComponent<Animation>().Play("AttackAnimations");

        if(Input.GetKey(KeyCode.L))
        {
            transform.Find("Sword").gameObject.GetComponent<Animation>().Play("SwordRightSlash");
        }

        if (Input.GetKey(KeyCode.K))
        {
            transform.Find("Sword").gameObject.GetComponent<Animation>().Play("SwordLeftSlash");
        }

        /*
        if (Input.GetKey(KeyCode.N))
        {
            transform.Find("Sword").gameObject.transform.Rotate(0, 0, 90 * Time.deltaTime);
        }
        */
    }

}
