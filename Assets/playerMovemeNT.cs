using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/**
- gleichbleibende velocity 
- jump ? 
- change direction via keys
- 
*/
public class playerMovemeNT : MonoBehaviour
{

 public UserInput controls;

    void Awake(){
        controls.Player.Move.performed += _ => Move();
    }

    void Move(){
        Debug.Log("work");
    }

    private void onEnable(){
        controls.Enable();
    }   
}

/**
public Rigidbody rb;
    public Transform tf;
    public int speed = 10;
    public string key = "";
    public Vector3 direction;
    public string currentAxis;
    public float lastPress;

    // Start is called before the first frame update
    void Start(){
        direction = new Vector3(0, 0, speed);
        currentAxis = "+z";
        lastPress = 0;
    }

    void changeAxis(KeyCode code){
        switch(currentAxis){
            case "+z":
               if(code == KeyCode.LeftArrow){
                    direction = new Vector3(-speed, 0, 0);
                    currentAxis = "-x";
               }else if(code == KeyCode.RightArrow){
                    direction = new Vector3(speed, 0, 0);                 
                    currentAxis = "+x";
               }
               break;
            case "+x":
                if(code == KeyCode.LeftArrow){
                    direction = new Vector3(0, 0, speed);
                    currentAxis = "+z";
               }else if(code == KeyCode.RightArrow){
                    direction = new Vector3(0, 0, -speed);
                    currentAxis = "-z";
               }
               break;
            case "-x":
                if(code == KeyCode.LeftArrow){
                    direction = new Vector3(0, 0, -speed);
                    currentAxis = "-z";
               }else if(code == KeyCode.RightArrow){
                    direction = new Vector3(0, 0, speed);
                    currentAxis = "+z";
               }
               break;
            case "-z":
                if(code == KeyCode.LeftArrow){
                    direction = new Vector3(speed, 0, 0);
                    currentAxis = "+x";
               }else if(code == KeyCode.RightArrow){
                    direction = new Vector3(-speed, 0, 0);
                    currentAxis = "-x";
               }
               break;
        }   
    }

    // Object Movement
    void FixedUpdate()
    {
        //rb.AddForce(0,0, moveForward * Time.deltaTime); //moveSideways * Time.deltaTime
        transform.Translate( direction * Time.deltaTime, Space.World);
        //Debug.Log(direction);
        if(Input.GetKeyUp(KeyCode.LeftArrow)){
            if(lastPress + 0.05 < Time.time){
                tf.Rotate(0f, 90f, 0f, Space.Self);
                changeAxis(KeyCode.LeftArrow);
                lastPress = Time.time;
                Debug.Log(Time.time);
            }
        }else if(Input.GetKeyUp(KeyCode.RightArrow)){
            if(lastPress + 0.05 < Time.time){
                tf.Rotate(0f, 270f, 0f, Space.Self);
                changeAxis(KeyCode.RightArrow);
                lastPress = Time.time;
                Debug.Log(Time.time);
            } 
        }

        if(rb.position.y <= -50){
            //Application.Quit();
            Debug.Break(); 
        }
    }
*/
