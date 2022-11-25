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
    public Material glass;


    void Start()
    {        
        // Debug.Log("health:" + Bladehealth);
        
    }
    
    void Update()
    {
        GameObject exitDoor = GameObject.Find("exit-door");
        if (Bladehealth == 0f){
            // stopBelt();
            exitDoor.GetComponent<Renderer>().material = glass;
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

    void openDoorAnimation()
    {
        GetComponent<Renderer>().material = LoadResourceAsMaterial("Assets/BossLevelAsset/Materials/Glass.mat");
    }

    Material LoadResourceAsMaterial(string resourcePath){
        return Resources.Load(resourcePath, typeof(Material)) as Material;
    }
    
}
