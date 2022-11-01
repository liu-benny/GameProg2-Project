using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip burningClip;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject fire2;
    [SerializeField] private GameObject fire3;

    // float initial_x;
    // float initial_y;
    // float initial_z;
    private int time;
    private bool isVisible;
    private System.DateTime delay;
    private System.DateTime current_time;

    
    void Start()
    {
        time = Random.Range(3, 7); 
        isVisible = true;
        current_time = System.DateTime.Now;
        delay = current_time.AddSeconds(time);
        // initial_x = fire.transform.position.x;
        // initial_y = fire.transform.position.y;
        // initial_z = fire.transform.position.z;
         Debug.Log("fire-x: " + fire.transform.position.x + "fire-y: " + fire.transform.position.y + "fire-z: " + fire.transform.position.z);
    }

    void Update()
    {
        if (System.DateTime.Now > delay)
        {
            current_time = System.DateTime.Now;
            time = Random.Range(1, 3);
            delay = current_time.AddSeconds(time);
            // Set fire "invisible"
            if (isVisible == true)
            {
                isVisible = false;
                fire.transform.position = new Vector3(fire.transform.position.x, 4.0f, fire.transform.position.z);
                fire2.transform.position = new Vector3(fire2.transform.position.x, 4.0f, fire2.transform.position.z);
                fire3.transform.position = new Vector3(fire3.transform.position.x, 4.0f, fire3.transform.position.z);
            }
            // Set fire visible
            else
            {
                isVisible = true;
                fire.transform.position = new Vector3(fire.transform.position.x, fire.transform.position.y, fire.transform.position.z);
                fire2.transform.position = new Vector3(fire2.transform.position.x, fire2.transform.position.y, fire2.transform.position.z);
                fire3.transform.position = new Vector3(fire3.transform.position.x, fire3.transform.position.y, fire3.transform.position.z);
            }
        }
    }
           

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name == "beefyBoy")
        {
            movementBB beefyBoyMovement = collider.gameObject.GetComponent<movementBB>();
            if (beefyBoyMovement != null && beefyBoyMovement.health > 0)
            {
                beefyBoyMovement.health--;
                Debug.Log("Health: " + beefyBoyMovement.health);
            }
            if (beefyBoyMovement.health == 0)
            {
                audioSource.Stop();
            }
            if (!audioSource.isPlaying){
                audioSource.PlayOneShot(burningClip);
            }
        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.name == "beefyBoy"){
            if (audioSource.isPlaying){
                audioSource.Stop();
            }
        }
    }
}
