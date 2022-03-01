using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set;}
    private AudioSource source;
    private float mvol; // Global music volume
    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        mvol = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        source.volume = mvol;
    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }
    
    public void musicVolumeChanged() {
        mvol = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        source.volume = mvol;
    }
}
