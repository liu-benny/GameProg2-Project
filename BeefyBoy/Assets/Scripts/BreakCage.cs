using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCage : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 velocityBeforePhysicsUpdate;
    GameObject beefyBoy;

    [SerializeField] GameObject explosion;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        beefyBoy = GameObject.Find("beefyBoy");
    }

    void FixedUpdate()
    {
        velocityBeforePhysicsUpdate = rigidbody.velocity;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        float speed = velocityBeforePhysicsUpdate.y;
        
        Debug.Log(speed);

        //todo threshold change later
        if (speed < -4.0 && other.gameObject != beefyBoy && this.gameObject.activeInHierarchy) {

            ContactPoint contact = other.contacts[0];
            Vector3 pos = contact.point;
            Instantiate(explosion, pos, Quaternion. Euler(-90, 0, 0));

            this.gameObject.SetActive(false);
        }
    }
}
