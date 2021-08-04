using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance; 
    public static SoundManager Instance { get { return instance; } }
    
    public AudioSource soundeffects;
    public AudioSource soundMusic;

    public SoundType[] Sounds;

    public bool IsMute = false;

    public float Volume = 1f;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(global::Sounds.Music);
    }

    public void SetVolume(float volume)
    {
        Volume = volume;
        soundeffects.volume = Volume;
        soundMusic.volume = Volume;
    }

    public void Mute(bool status)
    {
        IsMute = status;
    }
    public void PlayMusic(Sounds sound)
    {
        if (IsMute)
            return;
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();

        }
        else
        {
            Debug.LogError("Clip not found for sound type" + sound);
        }
    }
    public void Play(Sounds sound)
    {
        if (IsMute)
            return;
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundeffects.PlayOneShot(clip);

        }
        else
        {
            Debug.LogError("Clip not found for sound type" + sound);
        }

    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, item => item.soundType == sound);
        if (item != null)
            return item.soundClip;
        return null;
    }
}

    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip soundClip;
    }
    public enum Sounds
    {
        ButtonClick,
        Music,
        PlayerMove,
        PlayerDeath,
        EnemyDeath,
        PlayerJump,
    }

