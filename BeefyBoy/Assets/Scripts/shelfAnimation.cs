using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelfAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "beefyBoy"){
            anim.enabled = true;
            anim.Play("Shelf");
        }
    }
}
