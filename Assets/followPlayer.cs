using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camera follows Player
public class followPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;


    private void Start(){
        offset = player.transform.position - transform.position;
    }


    // Update is called once per frame
    void FixedUpdate()
    { 
        float angle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = player.transform.position - (rotation * offset);
        transform.LookAt(player.transform);
    }
}
