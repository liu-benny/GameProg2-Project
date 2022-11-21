using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Pause;
    [SerializeField]
    private GameObject Resume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void PauseGame(){
      Time.timeScale = 0f;
      Pause.SetActive(true);
    }

    public void ResumeGame(){
      Pause.SetActive(false);
      Time.timeScale = 1f;
      
    }
}
