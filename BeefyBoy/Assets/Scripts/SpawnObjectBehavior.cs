using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectBehavior : MonoBehaviour
{
    public GameObject floor;
    public GameObject packagingBoxBuilding;
    
    void Start()
    {
        packagingBoxBuilding = GameObject.Find("qw1/low_buildingH");
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
