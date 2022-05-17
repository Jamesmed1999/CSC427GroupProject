using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip Clip;

    [Range(0f,1f)]
    public float volume;

    [Range(.1f, 5f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
