using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatelight : MonoBehaviour
{
    public Transform light;
    //rotates light source 
    void Update()
    {
       light.Rotate(0.5f, 0.2f, 0f); 
    }
}
