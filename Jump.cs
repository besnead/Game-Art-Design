using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public float jumpHeight = 7f;
    public bool isGrounded;
    public float NumberJumps = 0f;
    public float MaxJumps = 2;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // You must define a Jump function in InputSystem and assign a jump key. See documentation in google drive folder.
    void OnJump()
    {
        if (NumberJumps > MaxJumps - 1)
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            //Debug.Log("Jump pressed.");
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            NumberJumps += 1;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        NumberJumps = 0;
    }
   
}
