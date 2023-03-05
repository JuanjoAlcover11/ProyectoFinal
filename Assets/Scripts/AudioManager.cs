using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] music;
    public AudioSource[] sfx;

    public AudioMixerGroup musicMixer, sfxMixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PlayMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic(int musicToPlay)
    {
        music[musicToPlay].Play();
    }

    public void PlaySFX(int SFXToPlay)
    {
        sfx[SFXToPlay].Play();
    }

    public void SetMusicLevel()
    {
        musicMixer.audioMixer.SetFloat("MusicVolume", UIManager.instance.musicSlider.value);
    }
    public void SetSFXLevel()
    {
        sfxMixer.audioMixer.SetFloat("SFXVolume", UIManager.instance.sfxSlider.value);
    }
}
