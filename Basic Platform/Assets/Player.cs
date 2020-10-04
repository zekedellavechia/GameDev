using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform groundCheckTransform;
    public LayerMask playerMask;


    Rigidbody rb;
    bool jumpKeyWasPressed;
    float horizontalInput;
    int superJumpsRemaining;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Jump"))
        {
            jumpKeyWasPressed = true;
        }


        horizontalInput = Input.GetAxis("Horizontal");

    }


    private void FixedUpdate()
    {

        rb.velocity = new Vector3(horizontalInput, rb.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            float jumpPower = 5f;
            if (superJumpsRemaining >0)
            {
                jumpPower *= 2;
                superJumpsRemaining--;
            }    
            rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
    }

}
