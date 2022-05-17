using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    // Attach this script to the focal point parent object of the camera

    public GameObject player;
    public float rotationSpeed = 50.0f;

    private float horizontalInput;

    // Get the input from the mouse and assign it to horzontalInput
    void OnLook(InputValue rotateValue)
    {
        horizontalInput = rotateValue.Get<Vector2>().x;
    }

    // Update is called once per frame
    void Update()
    {
        // Follows the players transform
        transform.position = player.transform.position;
        // Apply the rotation from the mouse
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
