#pragma strict

function Start (){
 
     if(GetComponent.<NetworkView>().isMine){
         GetComponent(Camera).enabled = true;
     }
     else{
         GetComponent(Camera).enabled = false;
     }
 }