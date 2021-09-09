using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayHelper : MonoBehaviour
{
    public KeyCode keycode = KeyCode.Q;
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            Play();
        }
    }
    public void Play()
    {
        audioSource.Play();
    }
}
