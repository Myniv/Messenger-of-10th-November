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

    public static AudioManager instance;
    private void Start() 
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

    }
    public void PlaySFX (AudioClip clip) 
    {
        Sfx.PlayOneShot(clip);
    }

    public void IsMute(){
        Bgm.mute = !Bgm.mute;
        Sfx.mute = !Sfx.mute;
    }
}
