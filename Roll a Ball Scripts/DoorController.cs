using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject[] doors;
    public GameObject[] keys;

    private int keyIndexNum = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            for (int i = 0; i < keys.Length; i++)
            {
                //Debug.Log("Key name " + keys[i] + " keyObject.name " + other.name);
                if (keys[i].name == other.name)
                {
                    keyIndexNum = i;
                }
            }
            //Debug.Log("Entered " + other.name + " with index of " + keyIndexNum);
            other.gameObject.SetActive(false);
            doors[keyIndexNum].SetActive(false);
        }
    }
}
