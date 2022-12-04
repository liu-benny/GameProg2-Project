using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name.Equals("beefyBoy") && blade.GetComponent<BladeDestroy>().checkBladeHealthIsZore() ){
            winScreen.SetActive(true);
        }
        
    } 

    public void PlayAgainButton(string MainMenu){
        SceneManager.LoadScene(MainMenu);

    }
}
