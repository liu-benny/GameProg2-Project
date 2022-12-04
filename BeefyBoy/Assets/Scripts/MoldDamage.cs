using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoldDamage : MonoBehaviour
{
    GameObject beefyBoy;
    Transform beefyBoyTransform;
    Rigidbody beefyBoyRigidbody;
    MovementBB beefyBoyMovement;
    Transform moldTransform;
    Vector3 velocityBeforePhysicsUpdate;
    GameObject playerUI;
    HealthBar healthBar;
    [SerializeField] GameObject parentObject;
    
    // Start is called before the first frame update
    void Start()
    {
        beefyBoy = GameObject.Find("beefyBoy");
        beefyBoyMovement = beefyBoy.GetComponent<MovementBB>();
        beefyBoyTransform = beefyBoy.GetComponent<Transform>();
        beefyBoyRigidbody = beefyBoy.GetComponent<Rigidbody>();
        moldTransform = GetComponent<Transform>();
        
        playerUI = GameObject.Find("HealthBar");
        healthBar = playerUI.GetComponent<HealthBar>();
    }

    void FixedUpdate()
    {
        velocityBeforePhysicsUpdate = beefyBoyRigidbody.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        float fallSpeed = velocityBeforePhysicsUpdate.y;

        if (other.gameObject.name == "beefyBoy") {
            if (fallSpeed <= -3.0) {
                parentObject.gameObject.SetActive(false);
                Destroy(parentObject);
            }
            else {
                beefyBoyRigidbody.AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
                beefyBoyMovement.health -= 10;
                healthBar.SetHealth(beefyBoyMovement.health);
            }
        }
    }
}
