using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource[] BackgroundMusicSource, SFXSource;

    private void Awake()
    {
        Setting.SfxVolume = 1f;
        Setting.BgmVolume = 1f;
        
        if (PlayerPrefs.GetInt("Initialization") == 0)
        {
            PlayerPrefs.SetInt("Initialization", 1);
            PlayerPrefs.SetFloat("SliderVolumeValue", 1);
        }
        
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeMasterVolume(PlayerPrefs.GetFloat("SliderVolumeValue"));
    }

    private void Update()
    {
        float BGMVolume = Setting.BgmVolume;
        float SFXVolume = Setting.SfxVolume;
        for (int i = 0; i < SFXSource.Length; i++)
        {
            SFXSource[i].GetComponent<AudioSource>().volume = BGMVolume;
        }

        for (int i = 0; i < BackgroundMusicSource.Length; i++)
        {
            BackgroundMusicSource[i].GetComponent<AudioSource>().volume = SFXVolume;
        }
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ToggleMusic(bool value)
    {
        for (int i = 0; i < BackgroundMusicSource.Length; i++)
        {
            BackgroundMusicSource[i].mute = value;
        }
    }

    public void ToggleEffects(bool value)
    {
        for (int i = 0; i < SFXSource.Length; i++)
        {
            SFXSource[i].mute = value;
        }
    }

    public void PlaySFX(string name)
    {
        for (int i = 0; i < SFXSource.Length; i++)
        {
            if (SFXSource[i].name == name)
            {
                SFXSource[i].GetComponent<AudioSource>().Play();
            }
        }
    }

    public void PlayBGM(string name)
    {
        for (int i = 0; i < BackgroundMusicSource.Length; i++)
        {
            BackgroundMusicSource[i].GetComponent<AudioSource>().Stop();
        }

        for (int i = 0; i < BackgroundMusicSource.Length; i++)
        {
            if (BackgroundMusicSource[i].name == name)
            {
                BackgroundMusicSource[i].GetComponent<AudioSource>().Play();
            }
        }
    }

    public class Setting
    {
        public static float SfxVolume
        {
            get { return PlayerPrefs.GetFloat("sfxVolume"); }
            set { PlayerPrefs.SetFloat("sfxVolume", value); }
        }

        public static float BgmVolume
        {
            get { return PlayerPrefs.GetFloat("bgmVolume"); }
            set { PlayerPrefs.SetFloat("bgmVolume", value); }
        }
    }
}
