using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    
    public void SetMasterVolume(float level)
    {
        // se usa Log10 porque los decibeles aumentan en una escala logaritmica, no lineal
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level)*20f);
    }

    public void SetSFXVolume(float level)
    {
        audioMixer.SetFloat("sfxVolume", Mathf.Log10(level)*20f);
    }
    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level)*20f);
    }
}
