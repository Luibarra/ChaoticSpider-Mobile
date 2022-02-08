using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCharacterController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float lookSens = 50;
    public float jumpForce = 500;
    public float chargeForce = 0; 
    private float horizontalInput, verticalInput, mouseHorizontal;
    private bool isGrounded = true;
    private bool canCharge = true; 
    

    private Rigidbody rb;
    //private Animator modelAnimator;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //modelAnimator = GetComponentInChildren<Animator>();
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);

        mouseHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, mouseHorizontal, 0) * lookSens * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }

        if(Input.GetButton("Charge") && canCharge)
        {
            canCharge = false; 
            rb.AddForce(transform.forward * chargeForce);
            StartCoroutine(ChargeTimer());
        }
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

    IEnumerator ChargeTimer()
    {
        yield return new WaitForSeconds(1);
        canCharge = true; 
    }
}
