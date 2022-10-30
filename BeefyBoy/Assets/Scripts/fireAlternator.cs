using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAlternator : MonoBehaviour
{

    private int counter = 200;
    private int fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fire = Random.Range(1,2);

    }
}
