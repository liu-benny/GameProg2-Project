using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeDestroy : MonoBehaviour
{
    public GameObject explodeEffect;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
       
        Destroy(other.gameObject);

        GameObject node = Instantiate(explodeEffect, null);
        node.transform.position = other.transform.position;

    }
}
