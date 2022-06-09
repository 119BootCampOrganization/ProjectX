using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Sound
{

    public string soundname;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    [HideInInspector]
    public AudioSource source;



}
