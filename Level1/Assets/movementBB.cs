using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementBB : MonoBehaviour
{   
    public Rigidbody rb;
    public Transform bb;
    public float force = 500f;
    public float jump = 100f;

    private float xInput, zInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector3(0,jump,0), ForceMode.Impulse);
        }

    }

    private void FixedUpdate() {
        rb.AddForce(new Vector3(xInput, 0f, zInput) * force);
    }
}
