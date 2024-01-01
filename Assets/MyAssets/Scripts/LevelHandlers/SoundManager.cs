using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    [SerializeField] AudioSource soundSFX;
    [SerializeField] AudioSource bgSound;
    [SerializeField] SoundType[] soundsInGame;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayBackgroundMusic()
    {
        AudioClip clipBG = GetAudioClip(Sounds.background);
        bgSound.clip = clipBG;
        bgSound.Play();
    }
    public void PlaySFX(Sounds soundName)
    {
        AudioClip audio = GetAudioClip(soundName);
        soundSFX.PlayOneShot(audio);
    }
    private AudioClip GetAudioClip(Sounds soundName)
    {
        SoundType item=Array.Find(soundsInGame,i=>i.sound==soundName);
        if (item != null)
        {
            return item.audioClip;
        }
        return null;
    }
    [Serializable] class SoundType
    {
        public Sounds sound;
        public AudioClip audioClip;
    };

    public enum Sounds
    {
        background,
        deathScreen,
        PlayerDeath,
        pause,
        blockedPath,
        buttonSelect,
        LevelComplete,
        jump,
        powers,
        shoot,
        Damage,
        jumperlong,
        nill
    }
}
