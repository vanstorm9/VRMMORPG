#pragma strict

var cam : GameObject;
 
 function Update()
 {
     if (!GetComponent.<NetworkView>().isMine)  // if this is not my player, remove the camera
         Destroy(cam);
         Debug.Log("Destroyed Cam");
 }