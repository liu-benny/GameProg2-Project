using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierObj : MonoBehaviour
{
    
    // speed of moving objects
    public float speed = 4f;
    public string direction = ""; 


    // if collision happened, call this method, and update for each frame
    public void OnCollisionStay(Collision other) {

        // put moving effect for objects that on the belt
        if (other.gameObject != null){
            MoveObj(other.gameObject);
        }
    }
    

    // move the object that on the belt 
    public void MoveObj(GameObject gameObject){
        if(direction == "forward"){
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }else if(direction == "right"){
            gameObject.transform.Translate(Vector3.right *speed * Time.deltaTime, Space.World);
        }else{
            gameObject.transform.Translate(Vector3.left *speed * Time.deltaTime, Space.World);
        }
        
    }

    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
