using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDamage : MonoBehaviour
{
    MovementBB beefyBoyMovement;
    CanvasGroup bloodIndicator;
    bool takeBloodDamage;
    GameObject playerUI;
    HealthBar healthBar;
    
    void Start()
    {
        beefyBoyMovement = GetComponent<MovementBB>();
        bloodIndicator = GameObject.Find("BloodEffect").GetComponent<CanvasGroup>();
        takeBloodDamage = false;

        playerUI = GameObject.Find("HealthBar");
        healthBar = playerUI.GetComponent<HealthBar>();
    }

    void Update()
    {
        if (!takeBloodDamage && bloodIndicator.alpha > 0.001f) {
            bloodIndicator.alpha -= 0.005f;
        }
    }

    void OnTriggerEnter(Collider other) {
        takeBloodDamage = true;
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.layer == 7 && other.gameObject.activeInHierarchy && bloodIndicator.alpha < 0.5f) {
            bloodIndicator.alpha += 0.01f;
            beefyBoyMovement.health--;
            healthBar.SetHealth(beefyBoyMovement.health);
        }
    }

    void OnTriggerExit(Collider other) {
        takeBloodDamage = false;
    }
}
