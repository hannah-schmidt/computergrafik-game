using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackPlayer : MonoBehaviour{
    
    public static int point_count;

    public void Start(){
        point_count = GameObject.FindGameObjectsWithTag("point").Length;
    }
    

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "point"){
            Debug.Log("point!");
            Destroy(other.gameObject, 0.1f);
            point_count -= 1; 
        }


        
    }
}
