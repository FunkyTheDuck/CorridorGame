using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    public void StopAllSounds()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source.Stop();
        }
    }
    public void PlayASound(string name, bool is3D)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null)
        {
            if(is3D)
            {
                s.source.spatialBlend = 1;
            }
            s.source.Play();

        }
        else
        {
            Debug.Log("Sound with name: " + name + " doesn't exist");
        }
    }
    public void StopASound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null)
        {
            s.source.Stop();
        }
        else
        {
            Debug.Log("Sound with name: " + name + " doesn't exist");
        }
    }
}