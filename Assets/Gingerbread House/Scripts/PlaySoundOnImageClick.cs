using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySoundOnImageClick : MonoBehaviour
{
    public Button button;        // Reference to the Button
    public AudioSource audioSource;  // Reference to the AudioSource

    void Start()
    {
        // Add a listener to the button's onClick event
        button.onClick.AddListener(PlaySound);
    }

    // Function to play the sound
    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
