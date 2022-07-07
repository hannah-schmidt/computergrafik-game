using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void PlayLevel(){
        if(score.score_count < 1){
            SceneManager.LoadScene(1, LoadSceneMode.Single); 
        }else{
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
        
    }

    public void startMenu(){
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void lostScreen(){
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }



}
