using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementBB : MonoBehaviour
{   
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip rollClip;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    public Rigidbody rb;
    public Transform cam;
    public float speed = 40f;
    public float jump = 60f;
    public int health = 100;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private float xInput, zInput;

    void Start()
    {
         rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xInput, 0f, zInput).normalized;
        /*
        --------To be Checked--------

        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.AddForce(moveDir.normalized, ForceMode.Impulse);
        }
       */

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.AddForce(moveDir.normalized * speed *Time.deltaTime);
        }
        if (Input.GetKeyDown("space"))
        // if (Input.GetKeyDown("space") && IsGrounded()) add this back later
        {
            rb.AddForce(new Vector3(0,jump,0), ForceMode.Impulse);
        }

        if (health <= 0)
        {
            Debug.Log("Beefy boy health reached 0. Beefy boy is dead!");
            //disables the gameObject and all its components
            this.gameObject.SetActive(false);
            //Removes a GameObject, component or asset.
            Destroy(this);
        
        }
    }

    //Method return true if the position of the GroundCheck overlaps with the ground
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
