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
   
    
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }

     public void StartGame(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("Level1");
    }

    public void ShowOptions(){
      // -- Fill in when options panel is done
    }

     public void QuitGame(){
        Debug.Log("Game Exit");
        UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }

   
}
