using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladeDestroy : MonoBehaviour
{
    public GameObject explodeEffect;
    [SerializeField]
    public GameObject healthBarplane;
    [SerializeField]
    public GameObject bladeText;
    float bladehealth = 1f; 
    public Material glass;

    [SerializeField]
    public GameObject doorOpen;

    [SerializeField]
    public GameObject deathScreen;

    AudioSource audioSource;
    public AudioClip destroyObjSound;



    void Start()
    {  
        audioSource = GetComponent<AudioSource>();      
     
        
    }
    
    void Update()
    {
        GameObject exitDoor = GameObject.Find("exit-door");
        if (checkBladeHealthIsZore()){
            // stopBelt();
            exitDoor.GetComponent<Renderer>().material = glass;
        }

        DoorOpenHint();
       
    }

    private void OnTriggerEnter(Collider other) {
        audioSource.PlayOneShot(destroyObjSound);
        Destroy(other.gameObject);

        GameObject node = Instantiate(explodeEffect, null);
        node.transform.position = other.transform.position;

        if(other.gameObject.name.Equals("potStew(Clone)") || other.gameObject.name.Equals("meatTenderizer(Clone)") 
                    || other.gameObject.name.Equals("pan(Clone)") || other.gameObject.name.Equals("can(Clone)") ){
            bladehealth -= 0.2f;
            healthBarplane.GetComponent<Image>().fillAmount = bladehealth;
        }

        if(other.gameObject.name.Equals("beefyBoy") ){
            deathScreen.SetActive(true);
        }

    }

    private void DoorOpenHint(){
      
        if(checkBladeHealthIsZore()) {
            bladeText.SetActive(false);
            doorOpen.SetActive(true);
            Invoke("DisableDoorOpenHint", 3f);
        }
        
    }

    private void DisableDoorOpenHint(){
        doorOpen.SetActive(false);
    }


    void openDoorAnimation()
    {
        GetComponent<Renderer>().material = LoadResourceAsMaterial("Assets/BossLevelAsset/Materials/Glass.mat");
    }

    private bool checkBladeHealthIsZore(){
        const float EPSINON = 0.000001f; 
        if(( bladehealth >= -EPSINON ) && ( bladehealth <= EPSINON )) {
            return true;
        }else{
            return false;
        }
    }

    Material LoadResourceAsMaterial(string resourcePath){
        return Resources.Load(resourcePath, typeof(Material)) as Material;
    }
    
}
