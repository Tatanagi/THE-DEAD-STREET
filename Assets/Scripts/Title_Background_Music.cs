using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Background_Music : MonoBehaviour
{
     private AudioSource bgmAudioSource;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        bgmAudioSource = GetComponent<AudioSource>();

        // Start playing the background music
        bgmAudioSource.Play();
    }

}
