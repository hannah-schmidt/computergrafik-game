using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    private UserInput controls;
    public Rigidbody rb;
    public Transform tf;
    public int speed = 10;
    public Vector3 direction;
    public string currentAxis  = "+z";
    private bool duration =false;
    private string name;

    private void Awake(){
        controls = new UserInput();
        controls.Player.Enable();
        controls.Player.Move.started += ctx => { 
            duration = true;
            name = ctx.control.name;
            };
        controls.Player.Move.canceled += ctx => {
            duration = false;
            name = ctx.control.name;
        };
    }

     // Start is called before the first frame update
    void Start(){
        direction = new Vector3(0, 0, speed);
    }


    void changeAxis(string code){
        if(code == "leftArrow"){
            Debug.Log("left");
            tf.Rotate(0f, -1f, 0f, Space.Self);
        }else if(code == "rightArrow"){
            tf.Rotate(0f, 1f, 0f, Space.Self);
            Debug.Log("right");
        }else if(code == "upArrow"){
            rb.AddForce(Vector3.up * 4f,ForceMode.Impulse);
            Debug.Log("up");
        }
        
    }

    public void FixedUpdate(){
        tf.Translate(Vector3.forward * 20 * Time.deltaTime, Space.Self); 
        if(duration == true){
            changeAxis(name);
        }
        if(rb.position.y < 6){
            rb.AddForce(new Vector3(0, -20f, 0),ForceMode.Impulse); 
        }
        if(rb.position.y <= -100){
            Debug.Log("exit");
            Debug.Break();  //later Application.Quit();
        }
    }
 
}


/*

switch(currentAxis){
            case "+z":
               if(code == "leftArrow"){
                    direction = new Vector3(-speed, 0, 0);
                    currentAxis = "-x";
               }else if(code == "rightArrow"){
                    direction = new Vector3(speed, 0, 0);                 
                    currentAxis = "+x";
               }
               break;
            case "+x":
                if(code == "leftArrow"){
                    direction = new Vector3(0, 0, speed);
                    currentAxis = "+z";
               }else if(code == "rightArrow"){
                    direction = new Vector3(0, 0, -speed);
                    currentAxis = "-z";
               }
               break;
            case "-x":
                if(code == "leftArrow"){
                    direction = new Vector3(0, 0, -speed);
                    currentAxis = "-z";
               }else if(code == "rightArrow"){
                    direction = new Vector3(0, 0, speed);
                    currentAxis = "+z";
               }
               break;
            case "-z":
                if(code == "leftArrow"){
                    direction = new Vector3(speed, 0, 0);
                    currentAxis = "+x";
               }else if(code == "rightArrow"){
                    direction = new Vector3(-speed, 0, 0);
                    currentAxis = "-x";
               }
               break;
     
        }   
*/
