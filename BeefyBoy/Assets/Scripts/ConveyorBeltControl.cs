using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltControl : MonoBehaviour
{

    public float x = 0;
    public float speed = 0.15f;


    void Start()
    {
        
    }

    void Update()
    {
        x = x + Time.deltaTime * speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, x);
        
    }
}
