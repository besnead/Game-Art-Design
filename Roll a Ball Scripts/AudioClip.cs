using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;



[RequireComponent(typeof(AudioSource))] // Make sure to put me before your public class!
public class PlayerController : MonoBehaviour
{
    public int gameVolume = 100;
    public AudioClip otherClip;
    public bool SomethingHappeningHere = true;

    void Update()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = otherClip; // Set the audio MP3 to be played in the Unity Inspector!
        if (!audio.isPlaying)
        {
            StartStopAudio(otherClip, true); // Play the audio clip that was defined over at audio.clip = otherClip, along with true to tell it to play something!
        }
        if (SomethingHappeningHere == true)
        {
            StartStopAudio(otherClip, false); // Feed it with the AudioClip above to stop the audio playing, along with false to tell it to stop playing something!
        }
    }

    void StartStopAudio(AudioClip clipName, bool StartStop)
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = clipName;
        audio.volume = gameVolume;
        if (StartStop)
        {
            audio.Play();
        }
        else
        {
            audio.Stop();
        }
    }
}
