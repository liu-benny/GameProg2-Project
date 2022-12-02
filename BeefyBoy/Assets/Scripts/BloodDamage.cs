using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDamage : MonoBehaviour
{
    MovementBB beefyBoyMovement;
    
    CanvasGroup bloodIndicator;
    
    bool takeBloodDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        beefyBoyMovement = GetComponent<MovementBB>();
        
        bloodIndicator = GameObject.Find("BloodEffect").GetComponent<CanvasGroup>();

        takeBloodDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!takeBloodDamage && bloodIndicator.alpha > 0.01f) {
            bloodIndicator.alpha -= 0.2f;
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("aaaaaaaaaa");
        takeBloodDamage = true;
    }

    void OnTriggerStay(Collider other) {
        Debug.Log("bbbbbbbbbb");
        if (other.gameObject.layer == 7 && other.gameObject.activeInHierarchy && bloodIndicator.alpha < 0.5f) {
            bloodIndicator.alpha += 0.2f;
        }
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("cccccccccc");
        takeBloodDamage = false;
    }
}
