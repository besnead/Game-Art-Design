using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using MEC;
public class SpeedBoostScript : MonoBehaviour
{
    //WARNING: Make sure that your Player Controller script class is specifically named "PlayerController"!!!!!!

    public float SpeedIncrement = 20; //You can adjust how much it's incremented by via the Unity Inspector! (By default, our friend here is 20.)

    private PlayerController playerControllerVar;
    private GameObject Player;

    private void Start()
    {
        playerControllerVar = Player.GetComponent<PlayerController>(); //Get access to the PlayerController scripts variables.
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedBoost")) //On collision with the trigger "SpeedBoost"
        {
            other.gameObject.SetActive(false); //Disable the SpeedBoost trigger, so that it isn't re-activated.
            Timing.RunCoroutine(OnSpeedBoost()); //And call the SpeedBoost Coroutine to start activating the speed-boost.
        }
    }

    private IEnumerator<float> OnSpeedBoost()
    {
        float ogSpeed = playerControllerVar.speed; //Create a new float to back up the original speed.
        speed += SpeedIncrement; //Adjust the speed you want added here, in this example, we're adding +20 speed.
        yield return Timing.WaitForSeconds(10f); //Keep the speed-boost running for 10 seconds.
        playerControllerVar.speed = ogSpeed; //Restore the old speed before with the backup.
        yield return Timing.WaitForOneFrame;
    }
}
