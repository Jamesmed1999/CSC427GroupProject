using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class audiomanagerMedina : Singleton<audiomanagerMedina>
{
    public Sound[] sounds;

    override public void Awake()
    {
       foreach (Sound snd in sounds)
        {
            snd.source = gameObject.AddComponent<AudioSource>();
            snd.source.clip = snd.Clip;
            snd.source.loop = snd.loop;
        }
    }
     void Update()
    {
        
    }

    public void Play(string name)
    {
        Sound s1 = Array.Find(sounds, sound => sound.name == name);
        s1.source.Play();
    }
}
