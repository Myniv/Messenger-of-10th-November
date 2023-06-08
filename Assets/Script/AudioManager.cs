using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("----Audio Source----")]
    [SerializeField] AudioSource Bgm;
    [SerializeField] AudioSource Sfx;
    

    [Header("----Audio Clip----")]
    //sfx dan bgm
    public AudioClip music;
    public AudioClip footstep;

    public static AudioManager instance;
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

        Bgm.clip = music;
        Bgm.Play();
        Bgm.volume = PlayerPrefs.GetFloat("musicVolume", 1);
        Sfx.volume = PlayerPrefs.GetFloat("SFXVolume", 1);
        Bgm.mute = PlayerPrefs.GetInt("Mute_FX") == 1 ? true : false;
        Sfx.mute = PlayerPrefs.GetInt("Mute_FX") == 1 ? true : false;
    }
    public void PlaySFX (AudioClip clip) 
    {
        Sfx.PlayOneShot(clip);
    }

    public void SetMute(bool Mute){
        Bgm.mute = Mute;
        Sfx.mute = Mute;
        
    }
}
