using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfAnimation : MonoBehaviour
{   
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip creekWood;

    private Animator anim;
    private GameObject particles;
    
    void Start()
    {
        anim = this.transform.parent.GetComponent<Animator>();
        particles = GameObject.Find("HintParticle");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "beefyBoy"){
            if (!audioSource.isPlaying){
                audioSource.PlayOneShot(creekWood);
            }
            anim.enabled = true;
            anim.Play("Shelf");
            particles.SetActive(false);
        }
        
    }
}
