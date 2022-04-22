using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController_Snead : MonoBehaviour
{
    // Private Variables only show up in the script and can only be edited internally
    private Rigidbody rb;
    private float movementX;
    private float movementY;
     

    // Public variables show up in the inspector and can be changed by user or other functions
    public int count;
    public int winCount;
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject menuObject; // I created a containter with all the pause menu items that gets turned on and off depending on the state of the game
    public AudioSource pickupAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Set the count to zero 
        count = 0;

        SetCountText(); // initialize the count text

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
        menuObject.SetActive(false);
    }

    // This function reads your input from the Input System and saves the x and y values as variables
    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // This runs roughly every frame but is independant of frame rate, so anything in this function gets checked every frame
    void FixedUpdate()
    {
        // Creates a vector called movement using the previously assigned input values from Input System 
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Applies force in the directions of the movement vector to move the ball and multiples the value by speed to make it go faster
        rb.AddForce(movement * speed);
    }

    // This function runs every time the player object enters the collider of another object set to Is Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Checks if the object is a "Pickup" then runs the code
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); // turns the object off (inactive)
            count = count + 1; // Updates the score value
            SetCountText(); // Updates the score in the UI
            pickupAudioSource.Play(); // Plays the pickup sound
        }
    }

    // This function will update the UI to display the score as well as display the Win Screen when the victory condition is met
    public void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); // Updates the UI for the score

        // checks if the count is equal to or greater than the victory condition then turns on the win screen
        if (count >= winCount)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true); // turns on win text
            menuObject.SetActive(true); // turns on the level select menu
        }
    }
}
