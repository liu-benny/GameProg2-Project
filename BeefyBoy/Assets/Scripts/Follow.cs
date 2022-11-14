using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject bb;
    public float xOffset, yOffset, zOffset;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = bb.transform.position + new Vector3(xOffset, yOffset, zOffset);
        transform.LookAt(bb.transform.position);
        
    }
}
