using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCage : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 velocityBeforePhysicsUpdate;
    GameObject beefyBoy;

    [SerializeField] GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        beefyBoy = GameObject.Find("beefyBoy");
    }

    void FixedUpdate()
    {
        velocityBeforePhysicsUpdate = rigidbody.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        //needs to check velocity BEFORE collision, right at the moment of impact before it decelerates to 0
        float speed = velocityBeforePhysicsUpdate.y;
        
        Debug.Log(speed);

        //falling at arbitrary speed. can/will be changed later.
        //
        //
        if (speed < -4.0 && other.gameObject != beefyBoy && this.gameObject.activeInHierarchy) {

            ContactPoint contact = other.contacts[0];
            Vector3 pos = contact.point;
            Instantiate(explosion, pos, Quaternion. Euler(-90, 0, 0));

            //disables cage
            this.gameObject.SetActive(false);
        }
    }
}
