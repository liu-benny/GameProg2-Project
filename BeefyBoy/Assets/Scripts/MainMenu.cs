using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
   
    [SerializeField]
    private GameObject StartButton;
    [SerializeField]
    private GameObject OptionsButton;
    [SerializeField]
    private GameObject QuitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void StartGame(){
        SceneManager.LoadScene("Level2");
    }

    public void ShowOptions(){
      //Fill in when options panel is done
    }

     public void QuitGame(){
        Debug.Log("Game Exit");
        Application.Quit();
    }
}
