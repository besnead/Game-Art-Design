using UnityEngine;

public class Wobble: MonoBehaviour
{
    public float tiltSpeed = 5f;
    public float maxTiltAngle = 30f;

    void Update()
    {
        // Get input from the keyboard
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate tilt angles based on input
        float tiltAroundX = Mathf.Clamp(verticalInput * tiltSpeed, -maxTiltAngle, maxTiltAngle);
        float tiltAroundZ = Mathf.Clamp(-horizontalInput * tiltSpeed, -maxTiltAngle, maxTiltAngle);

        // Apply tilting to the object
        Quaternion targetRotation = Quaternion.Euler(tiltAroundX, 0f, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * tiltSpeed);
    }
}
