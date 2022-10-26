using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementBB : MonoBehaviour
{   
    //Audio source for BB's movement
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip rollClip;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    public Rigidbody rb;
    public Transform cam;
    public float speed = 40f;
    public float jump = 60f;

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
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.AddForce(moveDir.normalized, ForceMode.Impulse);
        }
       
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            rb.AddForce(new Vector3(0,jump * 4,0), ForceMode.Impulse);
        }
        
    }

    // Method return true if the position of the GroundCheck overlaps with the ground
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    // Play the roll clip sound when collision with the furniture 
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Furniture"){
            if (!audioSource.isPlaying){
                audioSource.PlayOneShot(rollClip);
            }
        }
    }

}
