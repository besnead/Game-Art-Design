using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Things to note:
    // 1) you must make the key a trigger
    // 2) you need to assign an object in the editor to the door variable
    
    public GameObject door; // This is the object we want to disapear when the key is triggered

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Collision with Player object detected.");
            gameObject.SetActive(false); // Makes the key disapear in the scene
            door.gameObject.SetActive(false); // Makes the door disapear in the scene
        }
    }
}
