using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUI : MonoBehaviour
{

    private CanvasGroup oppacity;
    // Start is called before the first frame update
    void Start()
    {
        oppacity = this.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeathPopUp(){

        while(oppacity.alpha <= 1){
            oppacity.alpha -= 0.1f;
        }
    }
}
