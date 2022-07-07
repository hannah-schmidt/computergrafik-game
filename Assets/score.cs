using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public static int score_count = 0;
    public TextMeshProUGUI text;
 
    private void Start()
    {
        text.text = "Score: "+ score_count;
    }

    public void Update(){
        text.text = "Score: "+ score_count;
    }

    public void setScore(int add){
        score_count += add;
    }
}
