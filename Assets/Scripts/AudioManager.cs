using UnityEngine.Audio;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] Audio[] audios;
    private void Awake()
    {
        foreach(Audio audio in audios)
        {
            audio.source = gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.clip;
            audio.source.loop = audio.loop;
            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;
            audio.source.playOnAwake = false;
            
        }
    }

    public void play(string name)
    {
        foreach(Audio audio in audios)
        {
            if (audio.name == name)
            {
                audio.source.Play();
                return;
            }
        }
        Debug.LogError("Audio :" + name + "Not found");
    }
}
