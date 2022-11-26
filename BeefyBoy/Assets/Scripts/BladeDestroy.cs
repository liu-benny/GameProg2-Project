using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladeDestroy : MonoBehaviour
{
    public GameObject explodeEffect;
    [SerializeField]
    public GameObject HealthBarplane;
    [SerializeField]
    public GameObject bladeText;
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

        disableBladeText();
    }

    private void OnTriggerEnter(Collider other) {
       
        Destroy(other.gameObject);

        GameObject node = Instantiate(explodeEffect, null);
        node.transform.position = other.transform.position;

        if(other.gameObject.name.Equals("potStew(Clone)") || other.gameObject.name.Equals("meatTenderizer(Clone)") 
            || other.gameObject.name.Equals("pan(Clone)") || other.gameObject.name.Equals("can(Clone)") ){
            Bladehealth -= 0.2f;
            HealthBarplane.GetComponent<Image>().fillAmount = Bladehealth ;
            // HealthBarplane.GetComponent<Image>().fillAmount -= 0.2f;
            Debug.Log("health:" + Bladehealth);
            
        }

    }

    void disableBladeText(){
        // Debug.Log("disable function be called");
        if(checkBladeHealthIsZore()) {
            bladeText.SetActive(false);
        }
        
    }

    void openDoorAnimation()
    {
        GetComponent<Renderer>().material = LoadResourceAsMaterial("Assets/BossLevelAsset/Materials/Glass.mat");
    }

    private bool checkBladeHealthIsZore(){
        const float EPSINON = 0.000001f; 
        if(( Bladehealth >= -EPSINON ) && ( Bladehealth <= EPSINON )) {
            return true;
        }else{
            return false;
        }
    }

    Material LoadResourceAsMaterial(string resourcePath){
        return Resources.Load(resourcePath, typeof(Material)) as Material;
    }
    
}
