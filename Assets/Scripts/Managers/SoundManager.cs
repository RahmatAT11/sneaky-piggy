using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource bgmSource, effectSource;
    //DZ
    [SerializeField] private AudioSource[] DZ_bgmSource, DZ_effectSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        PlayerPrefs.SetInt("levelAt", 3);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void PlaySound (AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ToggleMusic(bool value)
    {
        bgmSource.mute = value;
    }

    public void ToggleEffects(bool value)
    {
        effectSource.mute = value;
    }

    public void DZ_PlayBGM(string name)
    {
        for (int i = 0; i < DZ_bgmSource.Length; i++)
        {
            DZ_bgmSource[i].GetComponent<AudioSource>().Stop();
        }

        for (int i = 0; i < DZ_bgmSource.Length; i++)
        {
            if (DZ_bgmSource[i].name == name)
            {
                DZ_bgmSource[i].GetComponent<AudioSource>().Play();
            }
        }
    }
}
