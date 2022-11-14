using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    UnityEngine.SceneManagement.Scene nextScene;
    GameObject beefyBoy;
    
    void Start()
    {
        beefyBoy = GameObject.Find("beefyBoy");

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == beefyBoy) {

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
