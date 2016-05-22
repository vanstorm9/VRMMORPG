using UnityEngine;
using System.Collections;

public class enemySwordReact : MonoBehaviour {

    void checkCollision(GameObject subject)
    {
        if (subject.name != "Plane")
        {
            Debug.Log("Collision: " + subject.name);
        }
    }

    void OnCollisionStay(Collision target)
    {

        checkCollision(target.transform.gameObject);
        if (target.transform.gameObject.name == "Sword")
        {
            //if (target.transform.gameObject.name == "Sword") {
            Debug.Log("Successful collision between swords");
            
        }

    }
}
