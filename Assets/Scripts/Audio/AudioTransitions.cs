using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransitions : MonoBehaviour
{
    public AudioMixerSnapshot snapshot;
    public float transtionTime = .1f;
    public Player player;

    public void MakeTransition()
    {
        snapshot.TransitionTo(transtionTime);
    }
    public void IsPaused()
    {
        player.isPaused = true;
    }
    public void NotPaused()
    {
        player.isPaused = false;
    }

}
