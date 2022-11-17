using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfAnimation : MonoBehaviour
{   
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip creekWood;
    private bool played = false;

    private Animator anim;
    private GameObject particles;
    
    void Start()
    {
        anim = this.transform.parent.GetComponent<Animator>();
        particles = GameObject.Find("HintParticle");
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.name == "beefyBoy"){
            if (!audioSource.isPlaying && played == false){
                audioSource.PlayOneShot(creekWood);
                played = true;
            }
            anim.enabled = true;
            anim.Play("Shelf");
            particles.SetActive(false);
        }
        
    }
}
