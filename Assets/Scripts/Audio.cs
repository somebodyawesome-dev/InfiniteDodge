using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Audio
{

    public AudioClip clip;
    public string name;
    [Range(0, 1)] public  float volume;
    [Range(.1f, 3f)] public float pitch;
    public bool loop;
    [HideInInspector] public AudioSource source;
}
