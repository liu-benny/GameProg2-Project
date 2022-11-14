using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlternator : MonoBehaviour
{

    private int counter = 200;
    private int fire;
    
    void Start()
    {
        
    }


    void Update()
    {
        fire = Random.Range(1,2);

    }
}
