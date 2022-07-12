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
    private AudioSource audio;
    private bool pressed;
    private string name;
    private bool hasPlayed;
    private float drift;
    private bool jump;
   

    private void Awake(){
        controls = new UserInput();
        controls.Player.Enable();
        controls.Player.Move.started += ctx => { 
            pressed = true;
            name = ctx.control.name;
        };
        controls.Player.Move.canceled += ctx => {
            pressed = false;
            name = ctx.control.name;
            jump = false;
        };
        controls.Player.Drift.started += ctx => { 
            drift = 2f;
        };
        controls.Player.Drift.canceled += ctx => {
            drift = 1f;
        };
        audio = GetComponent<AudioSource>();
        audio.volume = trackVolume.volval;
        Debug.Log(audio.volume);
        drift = 1f;
        pressed = false; 
        hasPlayed = false;
        jump = true;
    }

    // rotate/move according to keyboard key code
    void rotatePlayer(string code){
        if(code == "leftArrow"){
            tf.Rotate(0f, -1f * drift, 0f, Space.Self);
        }else if(code == "rightArrow"){
            tf.Rotate(0f, 1f * drift, 0f, Space.Self);
        }else if(code == "upArrow" && jump){
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        } 
    }
    // play Audio
    void playAudio(){
        audio.Play();
        hasPlayed = true;
    }

    public void FixedUpdate(){
        tf.Translate(Vector3.forward * 0.5f, Space.Self); 
        //rotate around itself for duration of pressed <- (key pressed)
        if(pressed)
            rotatePlayer(name);
        if(rb.position.y > 7){
            // wenn Player zu hoch oder key losgelassen -> jump = false;
            if(rb.position.y > 30)
                jump = false;
            if(!jump)
                rb.AddForce(new Vector3(0, -5f , -0.5f),ForceMode.Impulse);
        }else if(rb.position.y == 6){
            jump = true;
        }else if(rb.position.y < 4.5){ 
            if(hasPlayed == false){
                rb.AddForce(new Vector3(0, -60f, -0.5f), ForceMode.Impulse);
                playAudio();
            }
        }
        if(hasPlayed){
            if(trackPlayer.point_count > 0 && score.score_count > 0)
                score.score_count -= 1;
            if(!audio.isPlaying)
                SceneManager.LoadScene(2, LoadSceneMode.Single);    
        }
        if(trackPlayer.point_count < 1){
            score.score_count += 1;
            SceneManager.LoadScene(0, LoadSceneMode.Single); 
        }
        
    }
 
}