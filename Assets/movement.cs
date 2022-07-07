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
    private bool hasPlayed =false;
    private float drift=1f;
    private trackVolume vol;
   

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
        controls.Player.Drift.started += ctx => { 
            drift = 2f;
            Debug.Log("drift");
            };
        controls.Player.Drift.canceled += ctx => {
            drift = 1f;
            Debug.Log("no drift");
        };
    }
//
     // Start is called before the first frame update
    void Start(){
        direction = new Vector3(0, 0, speed);
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = vol.volval;
    }


    void changeAxis(string code){
        Debug.Log(code);
        if(code == "leftArrow"){
            tf.Rotate(0f, -30f * Time.deltaTime * drift, 0f, Space.Self);
        }else if(code == "rightArrow"){
            tf.Rotate(0f, 30f * Time.deltaTime * drift, 0f, Space.Self);
        }else if(code == "upArrow"){
            rb.AddForce(Vector3.up * 100f * Time.deltaTime, ForceMode.Impulse);
        }
        
    }
    void playAudio(){
        Debug.Log("Play");
        audio.Play();
    }

    public void FixedUpdate(){
        Debug.Log(rb.position.y);
        tf.Translate(Vector3.forward * 20 * Time.deltaTime, Space.Self); 
        if(duration == true){
            changeAxis(name);
        }
        if(rb.position.y < 5 && rb.position.y > -20){
            rb.AddForce(new Vector3(0, -30f, 0), ForceMode.Impulse);
            if(!hasPlayed){ 
               playAudio(); 
               hasPlayed = true;
            }
            
        }
        if(rb.position.y > 15){
            rb.AddForce(new Vector3(0, -20f * Time.deltaTime, 0),ForceMode.Impulse);
            //DISABLE UPARROW TILL ON THEGROUND AGAIN
        }
        if(trackPlayer.point_count < 1){
            Debug.Log("win"); 
            score.score_count += 1;
            SceneManager.LoadScene(0, LoadSceneMode.Single); 
        }
        if(rb.position.y < -1150){
            Debug.Log("lose");
            if(trackPlayer.point_count > 0 && score.score_count > 0){
                score.score_count -= 1;
            } 
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }
 
}