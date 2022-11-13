using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectBehavior : MonoBehaviour
{
    public GameObject packagingBoxBuilding;
    
    // Start is called before the first frame update
    void Start()
    {
        packagingBoxBuilding = GameObject.Find("qw1/low_buildingH");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject == packagingBoxBuilding) {
            Destroy(this.gameObject);
        }
    }
}
