using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    private UserInput controls;
    public Rigidbody rb;
    public Transform tf;
    public int speed = 10;
    public Vector3 direction;
    private bool duration =false;
    private string name;
    public score sc;
    public AudioClip gravity;
   

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

        audio.clip = gravity;
    }

     // Start is called before the first frame update
    void Start(){
        direction = new Vector3(0, 0, speed);
    }


    void changeAxis(string code){
        if(code == "leftArrow"){
            tf.Rotate(0f, -1f, 0f, Space.Self);
        }else if(code == "rightArrow"){
            tf.Rotate(0f, 1f, 0f, Space.Self);
        }else if(code == "upArrow"){
            rb.AddForce(Vector3.up * 4f,ForceMode.Impulse);
        }
        
    }

    public void FixedUpdate(){
        tf.Translate(Vector3.forward * 20 * Time.deltaTime, Space.Self); 
        if(duration == true){
            changeAxis(name);
        }
        if(rb.position.y < 6){
            rb.AddForce(new Vector3(0, -20f, 0),ForceMode.Impulse);
            audio.Play(); 
        }
        if(rb.position.y > 15){
            rb.AddForce(new Vector3(0, -4f, 0),ForceMode.Impulse);
        }
        if(trackPlayer.point_count < 1){
            Debug.Log("win"); 
            score.score_count += 1;
            SceneManager.LoadScene(0, LoadSceneMode.Single); 
        }
        if(rb.position.y < -100){
            Debug.Log("lose");
            if(trackPlayer.point_count > 0 && score.score_count > 0){
                score.score_count -= 1;
            } 
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }
 
}