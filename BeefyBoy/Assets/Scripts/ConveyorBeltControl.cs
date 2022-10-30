using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltControl : MonoBehaviour
{



    public float x = 0;
    public float speed = 0.15f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = x + Time.deltaTime * speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, x);
        
    }
}
