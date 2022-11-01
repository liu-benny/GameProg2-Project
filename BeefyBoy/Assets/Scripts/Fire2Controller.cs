using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2Controller : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip burningClip;
    [SerializeField] private GameObject fire2;

    float initialX;
    float initialY;
    float initialZ;
    private int time;
    private bool isVisible;
    private System.DateTime delay;
    private System.DateTime currentTime;

    
    void Start()
    {
        time = Random.Range(3, 7); 
        isVisible = true;
        currentTime = System.DateTime.Now;
        delay = currentTime.AddSeconds(time);
        initialX = fire2.transform.position.x;
        initialY = fire2.transform.position.y;
        initialZ = fire2.transform.position.z;
    }

    void Update()
    {
        if (System.DateTime.Now > delay)
        {
            currentTime = System.DateTime.Now;
            time = Random.Range(1, 3);
            delay = currentTime.AddSeconds(time);
            // Set fire "invisible"
            if (isVisible == true)
            {
                isVisible = false;
                fire2.transform.position = new Vector3(initialX, 4.0f, initialZ);
            }
            // Set fire visible
            else
            {
                isVisible = true;
                fire2.transform.position = new Vector3(initialX, initialY, initialZ);
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
