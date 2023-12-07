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
    private float dashTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashable = true;
        dashTimer = 0;
    }
    
    private void FixedUpdate()
    {
        dashTimer += Time.deltaTime;
        if (dashTimer > delayTime)
        {
            dashable = true;
        }
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    void OnDash()
    {
        if (dashable == true)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement.normalized * dashForce, ForceMode.Impulse);
            dashable = false;
            dashTimer = 0;
        }
    }

    IEnumerator DashDelay()
    {
        yield return new WaitForSeconds(delayTime);
    }
}
