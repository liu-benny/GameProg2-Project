using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrowningDamage : MonoBehaviour
{
    GameObject beefyBoy;
    MovementBB beefyBoyMovement;
    GameObject playerUI;
    HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        beefyBoyMovement = GameObject.Find("beefyBoy").GetComponent<MovementBB>();
        playerUI = GameObject.Find("HealthBar");
        healthBar = playerUI.GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "beefyBoy"){
            beefyBoyMovement.health = 0;
            healthBar.SetHealth(beefyBoyMovement.health);
        }
    }
}
