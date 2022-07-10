using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tracks number of points collected by Player in one level
public class trackPlayer : MonoBehaviour{
    
    public static int point_count;

    public void Start(){
        point_count = GameObject.FindGameObjectsWithTag("point").Length;
    }
    

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "point"){
            Destroy(other.gameObject, 0.1f);
            point_count -= 1; 
        }


        
    }
}
