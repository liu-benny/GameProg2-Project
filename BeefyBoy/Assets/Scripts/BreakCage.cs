using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCage : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 velocityBeforePhysicsUpdate;
    GameObject beefyBoy;

    [SerializeField] GameObject explosion;

    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip cageBreak;
    
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
        if (speed < -4.0 && other.gameObject.layer == 6 && this.gameObject.activeInHierarchy) {

            ContactPoint contact = other.contacts[0];
            Vector3 pos = contact.point;
            Instantiate(explosion, pos, Quaternion. Euler(-90, 0, 0));
            
            audioSource.PlayOneShot(cageBreak);
            this.gameObject.SetActive(false);

            beefyBoy.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            beefyBoy.GetComponent<FallDamage>().enabled = true;
        }
    }
}
