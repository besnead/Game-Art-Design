using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    string debugText;
    int buildArraySize;
    int currentIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        buildArraySize = SceneManager.sceneCountInBuildSettings;
        currentIndex = SceneManager.GetActiveScene().buildIndex;
        debugText = "";
    }

    // Update is called once per frame
    void Update()
    {
        LevelControllerFunction();
    }

    //Creates a debug text window on the UI Canvas
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 100, 1000, 40), debugText);
    }

    private void LevelControllerFunction()
    {
        //Loads next scene with '=' key
        if (Input.GetKeyDown(KeyCode.Equals) && currentIndex < buildArraySize - 1)
        {
            LoadNextScene();
        }
        //Loads previous scene with '-' key
        if (Input.GetKeyDown(KeyCode.Minus) && currentIndex != 0)
        {
            LoadPreviousScene();
        }
        //Loads the current scene again with 'backspace' key
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            RestartScene();
        }
        //Hold 'backslash' to display debug text
        if (Input.GetKey(KeyCode.Backslash))
        {
            debugText = "Number of Levels: " + buildArraySize + "\n" + "Current Scene Index: " + (currentIndex);
        }
        if (Input.GetKeyUp(KeyCode.Backslash))
        {
            debugText = "";
        }
    }

    public void LoadNextScene()
    {
        if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    public void LoadPreviousScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
