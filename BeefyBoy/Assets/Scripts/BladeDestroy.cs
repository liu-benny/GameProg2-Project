using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladeDestroy : MonoBehaviour
{
    public GameObject explodeEffect;
     [SerializeField]
    public GameObject HealthBarplane;
    float Bladehealth = 1f ; 
    
    void Start()
    {
        
        // Debug.Log("health:" + Bladehealth);
    }

    
    void Update()
    {
        if (Bladehealth == 0f){
            // stopBelt();
        }
    }

    private void OnTriggerEnter(Collider other) {
       
        Destroy(other.gameObject);

        GameObject node = Instantiate(explodeEffect, null);
        node.transform.position = other.transform.position;

        if(other.gameObject.name.Equals("pot(Clone)") || other.gameObject.name.Equals("meatTenderizer(Clone)" ) ){
            Bladehealth -= 0.2f;
            HealthBarplane.GetComponent<Image>().fillAmount = Bladehealth ;
            // HealthBarplane.GetComponent<Image>().fillAmount -= 0.2f;
            Debug.Log("health:" + Bladehealth);
            
        }

    }

    
}
