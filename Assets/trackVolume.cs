using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trackVolume : MonoBehaviour
{
     public Slider volumeSlider;
      public static float volval;

    public void Start(){
        AudioSource audio = GetComponent<AudioSource>();
        Debug.Log(volumeSlider.value);
        volval = volumeSlider.value;
        volumeSlider.onValueChanged.AddListener(delegate {VolumeChange(); });
    }

    public void VolumeChange(){
       volval = volumeSlider.value;
    }
}
