using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    private Vector3 checkpointPosition;
    private bool hasCheckpoint = false;
    private Rigidbody playerRigidbody;

    void Start()
    {
        // Get the Rigidbody component for further use
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object is a checkpoint
        if (other.CompareTag("Checkpoint"))
        {
            // Save the checkpoint position
            checkpointPosition = other.transform.position;
            hasCheckpoint = true;
            Debug.Log("Checkpoint reached: " + checkpointPosition);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object has the tag "Reset"
        if (collision.gameObject.CompareTag("Reset") && hasCheckpoint)
        {
            // Reset player position to the last checkpoint
            transform.position = checkpointPosition;

            // Stop the player's movement
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;
            }

            Debug.Log("Player reset to checkpoint: " + checkpointPosition);
        }
    }
}
