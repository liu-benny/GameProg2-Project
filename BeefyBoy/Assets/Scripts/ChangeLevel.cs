using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    UnityEngine.SceneManagement.Scene nextScene;
    GameObject beefyBoy;
    
    // Start is called before the first frame update
    void Start()
    {
        beefyBoy = GameObject.Find("beefyBoy");
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == beefyBoy) {
            //changes next scene to the one after, except with final level sending back to first
            if (SceneManager.GetActiveScene().name.Equals("SampleScene")) {
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name.Equals("Level2")) {
                SceneManager.LoadScene("BossLevel");
            }
            else {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
