using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCharacterController : MonoBehaviour
{
    public Camera Camera; 
    public float moveSpeed = 10;
    public float lookSens = 50;
    public float jumpForce = 500;
    public float chargeForce = 0; 

    private float horizontalInput, verticalInput, mouseHorizontal;
    private bool isGrounded = true;
    private bool canCharge = true;

    private Vector3 mouse; 

    private Rigidbody rb;
    //private Animator modelAnimator;

    [SerializeField] private joystickScript joystick; 
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //modelAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");  //button input
        verticalInput = Input.GetAxis("Vertical");

        if(joystick.InputDir != Vector2.zero)
        {
            horizontalInput = joystick.InputDir.x; //input changed if joystick being dragged
            verticalInput = joystick.InputDir.y; 
        }
        
        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);   //translate spider 

        /*if (verticalInput > 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime * -1);
        }
        else if (verticalInput < 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);
        }*/
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            Jump(); 
        }

        if (Input.GetButton("Charge"))
            Charge(); 
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground" || other.tag == "Points")
        {
            isGrounded = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ground" || other.tag == "Points")
        {
            isGrounded = false; 
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }
    public void Charge()
    {
        if (canCharge)
        {
            canCharge = false;
            rb.AddForce(transform.forward * chargeForce);
            StartCoroutine(ChargeTimer());
        }
    }

    IEnumerator ChargeTimer()
    {
        yield return new WaitForSeconds(1);
        canCharge = true; 
    }
}
