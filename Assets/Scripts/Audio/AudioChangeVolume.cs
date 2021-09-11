using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioChangeVolume : MonoBehaviour
{
    public AudioMixer group;
    public string floatParam = "VolumeBackground";

    public void ChangeVolume(float f)
    {
        group.SetFloat(floatParam, f);
    }
}
