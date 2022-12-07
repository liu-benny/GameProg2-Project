using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 velocityBeforePhysicsUpdate;
    GameObject beefyBoy;
    AudioSource audioSource;
    MovementBB beefyBoyMovement;
    GameObject playerUI;
    HealthBar healthBar;
    [SerializeField] AudioClip damageClip;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        beefyBoy = GameObject.Find("beefyBoy");
        playerUI = GameObject.Find("HealthBar");
        healthBar = playerUI.GetComponent<HealthBar>();
        audioSource = beefyBoy.GetComponent<AudioSource>();
        beefyBoyMovement = beefyBoy.GetComponent<MovementBB>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        velocityBeforePhysicsUpdate = rigidbody.velocity;
    }

    void OnCollisionEnter(Collision other) {
        float fallDamageSpeed = velocityBeforePhysicsUpdate.y;

        Debug.Log(fallDamageSpeed);

        // Debug.Log("Cake bounced yo ass");
        

        if (beefyBoyMovement != null && beefyBoyMovement.health > 0) 
        {
            Debug.Log(other.gameObject.name);

            if(other.gameObject.name != "Cylinder.003" && other.gameObject.name != "pillow"){
                if (fallDamageSpeed < -5.0 && other.gameObject.layer == 6 && this.gameObject.activeInHierarchy) {
                    int damageMultiplier = -7;
                    beefyBoyMovement.health -= (int) (damageMultiplier * fallDamageSpeed);
                    healthBar.SetHealth(beefyBoyMovement.health);
                    // Debug.Log("Health: " + beefyBoyMovement.health);
                    audioSource.PlayOneShot(damageClip);    
                }  
            }
              

           
        }
    }
}
