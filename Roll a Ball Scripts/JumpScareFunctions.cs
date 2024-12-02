using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScareFunctions : MonoBehaviour
{
    // #################################
    // Attach this script to your player
    // #################################
    
    [Header("Image Files:")]
    [Tooltip("This is the UI Image object that will display these images.")]
    public Image jumpScareFrame;
    [Tooltip("Hit the plus icon to add more files to the array.")]
    public Sprite[] jumpScareSprites;
    
    [Header("Sound Files:")]
    [Tooltip("Hit the plus icon to add more files to the array.")]
    public AudioClip[] jumpScareSounds;
    private AudioSource jumpScareSource;

    [Header("Jumpscare Settings:")]
    public float durationOfJumpScare = 0.3f;
    [Tooltip("Change this to the tag of the objects you want to trigger jumpscares")]
    // This defaults to your PickUp game object but if you want another trigger just put it in this variable.
    public string triggerTag = "PickUp";

    private void Start()
    {
        //Initialize variables and run some checks
        CompareArrays(jumpScareSprites, jumpScareSounds);
        jumpScareSource = GetComponent<AudioSource>(); //Finds the AudioScource attached to the same object this script is on.
        jumpScareFrame.enabled = false; //Turns off the jumpscare image
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            StartCoroutine(DisplayJumpScare(durationOfJumpScare));
        }
    }

    private IEnumerator DisplayJumpScare(float waitTime)
    {
        // Get a random index from the array
        int randomIndex = Random.Range(0, jumpScareSprites.Length);

        // Set the source image to a random sprite
        jumpScareFrame.sprite = jumpScareSprites[randomIndex];
        jumpScareFrame.enabled = true;
        
        // Set the random sound clip and then play it
        jumpScareSource.clip = jumpScareSounds[randomIndex];
        jumpScareSource.Play();
        
        // Wait for the specified number of seconds
        yield return new WaitForSeconds(waitTime);
        jumpScareFrame.enabled = false;
    }

    public void CompareArrays(Sprite[] array1, AudioClip[] array2)
    {
        // Check if both arrays have the same length
        if (array1.Length != array2.Length)
        {
            Debug.LogError("Error: The two arrays do not have the same length. Make sure that there are an equal number of sounds and images.");
            return; // Exit the function if lengths are not the same
        }

        // Continue with processing if lengths are the same
        Debug.Log("The two arrays have the same length. Proceeding as scheduled.");
    }

}
