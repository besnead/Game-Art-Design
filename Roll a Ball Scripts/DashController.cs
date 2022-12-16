using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashController : MonoBehaviour
{
    public float dashForce = 0;
    public int delayTime;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool dashable;
    private float jumpTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashable = true;
        jumpTimer = 0;
    }
    
    private void FixedUpdate()
    {
        movementX = rb.velocity.x;
        movementY = rb.velocity.z;
        jumpTimer += Time.deltaTime;
        if (jumpTimer > delayTime)
        {
            dashable = true;
        }
    }
    
    void OnDash()
    {
        if (dashable == true)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement.normalized * dashForce, ForceMode.Impulse);
            dashable = false;
            jumpTimer = 0;
        }
    }

    IEnumerator DashDelay()
    {
        yield return new WaitForSeconds(delayTime);
    }
}
