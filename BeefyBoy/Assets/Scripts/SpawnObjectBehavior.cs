using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectBehavior : MonoBehaviour
{
    public GameObject curtainCollider;
    public GameObject packagingBoxBuilding;
    
    void Start()
    {
        packagingBoxBuilding = GameObject.Find("curtains/curtainCollider");
        curtainCollider = GameObject.Find("otherCurtainCollider");

    }

    void Update()
    {
        
    }
    
    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject == packagingBoxBuilding) {
            Destroy(this.gameObject);
        }
        if (collision.gameObject == curtainCollider) {
            Destroy(this.gameObject);
        }
    }
}
