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
            //If the instance already exists, we destroy it
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //We play the first audio in our music array
        PlayMusic(0);
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
        //The music volume changes with the music slider
        musicMixer.audioMixer.SetFloat("MusicVolume", UIManager.instance.musicSlider.value);
    }
    public void SetSFXLevel()
    {
        //The SFX volume changes with the SFX slider
        sfxMixer.audioMixer.SetFloat("SFXVolume", UIManager.instance.sfxSlider.value);
    }
}
