using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackPlayer : MonoBehaviour{

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "point"){
            Debug.Log("point!");
            Destroy(other.gameObject, 0.1f); 
        }
        
    }
}
