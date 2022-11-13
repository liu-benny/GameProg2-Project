using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeDestroy : MonoBehaviour
{
    public GameObject explodeEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
       
        Destroy(other.gameObject);

        GameObject node = Instantiate(explodeEffect, null);
        node.transform.position = other.transform.position;

        
    }
}