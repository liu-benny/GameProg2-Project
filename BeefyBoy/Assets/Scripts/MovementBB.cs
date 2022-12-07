using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementBB : MonoBehaviour
{   
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip rollClip;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] private GameObject menu;
    [SerializeField]GameObject deathScreen;

    DeathUI dScript;
    Scene currentScene;
    public Rigidbody rb;
    public Transform cam;
    public Transform beefyBoyTransform;
    public float speed = 40f;
    public float jump = 60f;
    public int health = 100;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private float xInput, zInput;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        rb = GetComponent<Rigidbody>();
        beefyBoyTransform = GetComponent<Transform>();
        dScript = deathScreen.GetComponent<DeathUI>();
    }

    
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xInput, 0f, zInput).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.AddForce(moveDir.normalized * speed *Time.deltaTime);
        }

        Vector3 beefyBoyPosition = beefyBoyTransform.position;
        if (currentScene.name == "BossLevel") 
            groundCheck.position = new Vector3(beefyBoyPosition.x, beefyBoyPosition.y - 0.65f, beefyBoyPosition. z);
        else 
            groundCheck.position = new Vector3(beefyBoyPosition.x, beefyBoyPosition.y - 0.15f, beefyBoyPosition. z);

        if (Input.GetKeyDown("space") && IsGrounded())
            rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);

        if(Input.GetKeyDown(KeyCode.Escape)){
            menu.GetComponent<PauseMenu>().PauseGame();
        }

        if (health <= 0)
        {
            KillBeefyBoy();            
        }
    }
    
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground); 
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Floor" || other.gameObject.name == "curtainCollider" || other.gameObject.name == "otherCurtainCollider"){
            health = 0;
            KillBeefyBoy();
        }
        
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "WaterObstacle"){
            rb.drag = 3;
        } else{
            rb.drag = 1;
        }
    }
    
    void OnCollisionExit(Collision other) {
        
    }
    
    void KillBeefyBoy() {
        Debug.Log("Beefy boy health reached 0. Beefy boy is dead!");
        deathScreen.SetActive(true);
        this.gameObject.SetActive(false);
        Destroy(this);
    }
}
