using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectBehavior : MonoBehaviour
{
    public GameObject packagingBoxBuilding;
    
    void Start()
    {
        packagingBoxBuilding = GameObject.Find("qw1/low_buildingH");
    }

    void Update()
    {
        
    }
    
    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject == packagingBoxBuilding) {
            Destroy(this.gameObject);
        }
    }
}
