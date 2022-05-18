using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using MEC;

public class RespawnController : MonoBehaviour
{
    private Vector3 RespawnPosition = Vector3.one + Vector3.up; //Where to save the latest Respawn location, created by the RespawnPoints
    public Rigidbody rb; //MAKE SURE TO DEFINE THIS IN YOUR INSPECTOR AS YOUR PLAYER RIGIDBODY
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RespawnTrigger")) //This will be the trigger underneath the map to signify the player needs to be respawned.
        {
            rb.position = RespawnPosition; //Set the players position back to the RespawnPoint
            
            //Change the velocity to zero, so that the player isn't zooming off the RespawnPoint.
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("RespawnPoint")) //If you hit the collider with the tag RespawnPoint
        {
            //Go and save the new Respawn location in the RespawnPosition Vector3, just above the RespawnPoint object.
            RespawnPosition = other.rigidbody.position + Vector3.up; //Make sure that you give the RespawnPoint a RigidBody!!!
        }
    }
}
