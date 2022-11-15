using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*

    Scraped keeping incase i need in the future

*/
public class TutorialUI : MonoBehaviour
{   
    [SerializeField]
    public RectTransform movementTip;

    public float HorizontalSpeed = 1f;
    public float multiplier = -0.1f;
  
    void Start()
    {
        movementTip = GameObject.Find("MovementInfo").GetComponent<RectTransform>();
    }

    
    void Update()
    {
     Vector2 position = movementTip.anchoredPosition;
     
     if(position.x >= -259){
        position.x += (HorizontalSpeed * multiplier) * Time.deltaTime;
        movementTip.anchoredPosition = position;
     } else {
        StartCoroutine(Pause());
     }
    }

    //Re-check kinda sus
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(5);
        Vector2 position = movementTip.anchoredPosition;
        if(position.x <= 259){
        position.x += (HorizontalSpeed * Mathf.Abs(multiplier)) * Time.deltaTime;
        movementTip.anchoredPosition = position;
        }
        yield break;
    }

    public void pullOutCard(){
        movementTip = GameObject.Find("MovementInfo").GetComponent<RectTransform>();
        Debug.Log(movementTip);
            Vector2 position = movementTip.anchoredPosition;
            if(position.x >= -259){
                position.x += (HorizontalSpeed * multiplier) * Time.deltaTime;
                movementTip.anchoredPosition = position;
             } else {
                 StartCoroutine(Pause());
             }
            
    }
}
