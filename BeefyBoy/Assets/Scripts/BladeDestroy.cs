using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladeDestroy : MonoBehaviour
{
    float bladehealth = 0.2f; 
    public GameObject explodeEffect;
    [SerializeField]
    public GameObject healthBarplane;
    [SerializeField]
    public GameObject bladeText;
   
    public Material glass;

    [SerializeField]
    public GameObject doorOpenHint;

    [SerializeField]
    public GameObject deathScreen;

    AudioSource audioSource;
    public AudioClip destroyObjSound;

    private bool displayHint = true;

    public GameObject[] blets;

    public GameObject objSpawner;
    public GameObject boxSpawner;
    public GameObject blade;



    void Start()
    {  
        audioSource = GetComponent<AudioSource>();      
        
        
    }
    
    void Update()
    {
        GameObject exitDoor = GameObject.Find("exit-door");
        // Debug.Log("Health: " + bladehealth);
        if (checkBladeHealthIsZore()){
            exitDoor.GetComponent<Renderer>().material = glass;
        }

        if(displayHint){
            DoorOpenHint();
        }
      

        
       
    }

    private void OnTriggerEnter(Collider other) {
        audioSource.PlayOneShot(destroyObjSound);
        Destroy(other.gameObject);

        GameObject node = Instantiate(explodeEffect, null);
        node.transform.position = other.transform.position;

        if(other.gameObject.name.Equals("potStew(Clone)") || other.gameObject.name.Equals("meatTenderizer(Clone)") 
                    || other.gameObject.name.Equals("pan(Clone)") || other.gameObject.name.Equals("can(Clone)") ){
            bladehealth -= 0.2f;
            if(bladehealth < 0){
                bladehealth = 0;
            }
            healthBarplane.GetComponent<Image>().fillAmount = bladehealth;
        }

        if(other.gameObject.name.Equals("beefyBoy") ){
            deathScreen.SetActive(true);
        }

    }

    private void DoorOpenHint(){
      
        if(checkBladeHealthIsZore()) {
            Debug.Log("Enter the if, show then not show");
            bladeText.SetActive(false);
            doorOpenHint.SetActive(true);
            Invoke("DisableDoorOpenHint", 3f);
            BeltStopMove();
            displayHint = false;
            objSpawner.SetActive(false);
            boxSpawner.SetActive(false);
            blade.GetComponent<BladeBehavior>().rotationSpeed = 0;
        }
        
        
    }

    private void DisableDoorOpenHint(){
        doorOpenHint.SetActive(false);
        // Destroy(doorOpenHint);
    }


    void openDoorAnimation()
    {
        GetComponent<Renderer>().material = LoadResourceAsMaterial("Assets/BossLevelAsset/Materials/Glass.mat");
    }

    public bool checkBladeHealthIsZore(){
        const float EPSINON = 0.000001f; 
        if(( bladehealth >= -EPSINON ) && ( bladehealth <= EPSINON )) {
            return true;
        }else{
            return false;
        }
    }

    private void BeltStopMove(){
        foreach (GameObject obj in blets){
            obj.GetComponent<ConveyorBeltControl>().speed = 0f;
        }
            
     


    }

    Material LoadResourceAsMaterial(string resourcePath){
        return Resources.Load(resourcePath, typeof(Material)) as Material;
    }
    
}
