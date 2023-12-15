using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    //I reccoment that you attach this script to an empty game object called GameController
    
    public GameObject pauseMenu; //Create an empty parent object on your UI canvas to hold all of your pause menu UI components.
                                 //This will be made active/inactive by the script
    private bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        //Start the game with the pause menu off
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Debug.Log("Game Paused.");
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Debug.Log("Game Unpaused");
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
}
