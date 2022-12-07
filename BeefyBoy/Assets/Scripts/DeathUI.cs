using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUI : MonoBehaviour
{
    [SerializeField] GameObject dTitle;

    private float oppacityNum;
    private CanvasGroup oppacity;
    private CanvasGroup titleOppacity;
    // Start is called before the first frame update
    void Start()
    {
        oppacity = this.GetComponent<CanvasGroup>();
        titleOppacity = dTitle.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        oppacityNum = oppacity.alpha;
        if(oppacity.alpha <= 1){
            oppacity.alpha += 0.01f;
            titleOppacity.alpha +=0.00085f;
            // Debug.Log(oppacityNum);
        }
        
            
            
        
    }

    public void DeathPopUp(){
        Cursor.visible = true;
        this.gameObject.SetActive(true);
    }
}
