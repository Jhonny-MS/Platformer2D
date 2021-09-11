using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransitions : MonoBehaviour
{
    public AudioMixerSnapshot snapshot;
    public float transtionTime = .1f;    

    public void MakeTransition()
    {
        snapshot.TransitionTo(transtionTime);
    }
    public void IsPaused()
    {
        Time.timeScale = 0;
    }
    public void UnPaused()
    {
        Time.timeScale = 1;
    }

}
