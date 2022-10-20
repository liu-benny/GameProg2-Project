using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementBB : MonoBehaviour
{   
    public Rigidbody rb;
    public Transform cam;
    public float speed = 500f;
    public float jump = 20f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private float xInput, zInput;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xInput, 0f, zInput).normalized;

        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, angle, transform.eulerAngles.z);

            rb.AddForce(moveDir.normalized * speed *Time.deltaTime);
        }
       
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector3(0,jump,0), ForceMode.Impulse);
        }

    }


}
