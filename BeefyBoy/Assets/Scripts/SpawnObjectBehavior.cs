using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectBehavior : MonoBehaviour
{
    public GameObject floor;
    public GameObject packagingBoxBuilding;
    
    void Start()
    {
        packagingBoxBuilding = GameObject.Find("curtains/curtainCollider");
        floor = GameObject.Find("floor");

    }

    void Update()
    {
        
    }
    
    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject == packagingBoxBuilding) {
            Destroy(this.gameObject);
        }
        if (collision.gameObject == floor) {
            Destroy(this.gameObject);
        }
    }
}
