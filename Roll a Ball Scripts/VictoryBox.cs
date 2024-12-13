using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VictoryBox : MonoBehaviour
{
    public TextMeshProUGUI victoryText; // Assign your TextMeshPro object in the Inspector
    public float displayDuration = 3f; // Duration to display the victory message

    private void Start()
    {
        // Initially hide the victory text
        victoryText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player sphere collided
        if (other.CompareTag("Player"))
        {
            ShowVictoryMessage();
        }
    }

    private void ShowVictoryMessage()
    {
        // Show the victory text
        victoryText.gameObject.SetActive(true);

        // Start the coroutine to wait and load the next scene
        StartCoroutine(WaitAndLoadNextScene());
    }

    private IEnumerator WaitAndLoadNextScene()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("No more scenes to load. You are at the last scene.");
        }
    }
}
