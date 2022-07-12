using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // loads level 1 or level 2 depending on score 
    public void PlayLevel(){
        if(score.score_count < 1){
            SceneManager.LoadScene(1, LoadSceneMode.Single); 
        }else{
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
    }
    // loads start scene
    public void startMenu(){
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    // loads "you lost" scene
    public void lostScreen(){
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }



}
