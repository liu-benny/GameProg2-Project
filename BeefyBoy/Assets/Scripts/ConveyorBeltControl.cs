using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltControl : MonoBehaviour
{
    
    public float speed = 4f;
    public string direction = ""; 

    public float x = 0;
    // public float beltMaterialSpeed = 0.15f;

    public void OnCollisionStay(Collision other) {

        if (other.gameObject != null){
            MoveObj(other.gameObject);
        }
    }
    
    public void MoveObj(GameObject gameObject){
        if(direction == "forward"){
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }else if(direction == "right"){
            gameObject.transform.Translate(Vector3.right *speed * Time.deltaTime, Space.World);
        }else{
            gameObject.transform.Translate(Vector3.left *speed * Time.deltaTime, Space.World);
        }
        
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        x = x + Time.deltaTime * speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, x);
    }
}
