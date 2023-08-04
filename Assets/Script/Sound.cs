using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip[] clip;

    public AudioClip Get()
    {
        if (clip.Length == 0)
            return null;
        return clip[Random.Range(0, clip.Length)];

    }
}