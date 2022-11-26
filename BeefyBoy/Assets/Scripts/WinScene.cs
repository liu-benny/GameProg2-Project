using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScene : MonoBehaviour
{

    public GameObject winScreen;
    public GameObject blade;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other) {
        
        
        if(other.gameObject.name.Equals("beefyBoy") && blade.GetComponent<BladeDestroy>().checkBladeHealthIsZore() ){
            winScreen.SetActive(true);
        }

    }
}