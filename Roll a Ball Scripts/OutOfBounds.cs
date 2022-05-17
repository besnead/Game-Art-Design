using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    // To use this script, create an empty game object called Respawn point and make sure it is tagged "Respawn". This will be the location you respawn at.
    // Make sure your player is tagged as "Player".
    // Create a 3D Object > Cube called Boundary Box, turn off its Mesh Renderer, under Mesh Collider set to "is trigger". Attach this script to your Boundary Box.
    // Make sure the boundary box contains your entire level, every time the object tagged "Player" leaves this box's collider, it will reset to the spawn point.
    
    private GameObject player;
    private GameObject respawn;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        respawn = GameObject.FindWithTag("Respawn");
    }

    void OnTriggerExit(Collider other)
    {
        if(other = player.GetComponent<Collider>())
        {
            player.transform.position = respawn.transform.position;
        }
        
    }
}
