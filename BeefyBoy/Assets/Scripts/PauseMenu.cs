using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void RestartGame(){
      if (SceneManager.GetActiveScene().name.Equals("Level1")) {
                SceneManager.LoadScene("Level1");
                Pause.SetActive(false);
                Time.timeScale = 1f;
            }else if (SceneManager.GetActiveScene().name.Equals("Level2")) {
                SceneManager.LoadScene("Level2");
                Pause.SetActive(false);
                Time.timeScale = 1f;
            }
            else if (SceneManager.GetActiveScene().name.Equals("BossLevel")) {
                SceneManager.LoadScene("BossLevel");
                Pause.SetActive(false);
                Time.timeScale = 1f;
            }

    }

    public void TryAgain(){
      if (SceneManager.GetActiveScene().name.Equals("Level1")) {
                SceneManager.LoadScene("Level1");
            }else if (SceneManager.GetActiveScene().name.Equals("Level2")) {
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name.Equals("BossLevel")) {
                SceneManager.LoadScene("BossLevel");
            }
           
    }

    public void QuitGame(){
      Time.timeScale = 1f;
      SceneManager.LoadScene("MainMenu");
    }
}
