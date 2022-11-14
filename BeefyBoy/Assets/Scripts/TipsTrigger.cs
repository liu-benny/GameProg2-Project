using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsTrigger : MonoBehaviour
{
    TutorialUI ui;
    public RectTransform movementTip;
    private bool entered = false;
    public float HorizontalSpeed = 500f;
    public float multiplier = -100f;

    // Start is called before the first frame update
    void Start()
    {
         
         movementTip = GameObject.Find("MovementInfo").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {     
          Vector2 position = movementTip.anchoredPosition;
          if(entered){
          
     
          if(position.x >= -259){
               position.x += (HorizontalSpeed * multiplier) * Time.deltaTime;
               movementTip.anchoredPosition = position;
               Debug.Log(position.x);
               }
        }else if(!entered && position.x <= 259){
               position.x += (HorizontalSpeed * Mathf.Abs(multiplier)) * Time.deltaTime;
               movementTip.anchoredPosition = position;
               Debug.Log(position.x);
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

     private void OnTriggerEnter(Collider other){
        
        entered = true;
        Debug.Log(entered);
         if (other.gameObject.name == "beefyBoy") {
             entered = true;
               Debug.Log(entered);
         }
     }

     void OnTriggerExit(Collider other) {
         if (other.gameObject.name == "beefyBoy") {
             entered = false;
               Debug.Log(entered);
         }
     }
  }   

