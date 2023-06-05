using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class pengaturan : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start() 
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetBgmVolume();
            SetSFXVolume();
            SetMute();
        }
    }
    public void SetBgmVolume () 
    {
        float volume = volumeSlider.value;
        myMixer.SetFloat("BGM", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume () 
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void SetMute () 
    {
        AudioManager.instance.Mute();
    }
     private void LoadVolume()
     {
         volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
         SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
         SetBgmVolume();
         SetSFXVolume();
         SetMute();
     }

}
