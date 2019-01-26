using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public static AudioController instance = null;
    public AudioSource background;
    public AudioSource sudden;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        background = gameObject.AddComponent<AudioSource>();
        sudden = gameObject.AddComponent<AudioSource>();
    }

    public void PlayBackground(AudioClip ac)
    {
        background.clip = ac;
        background.Play();
    }


    public void PlaySudden(AudioClip ac)
    {
        sudden.clip = ac;
        sudden.Play();
    }

    public void Clear()
    {
        background.clip = null;
        sudden.clip = null;
    }
}
