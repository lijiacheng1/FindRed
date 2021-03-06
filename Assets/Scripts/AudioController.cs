﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public static AudioController instance = null;
    AudioSource background;
    AudioSource sudden;

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

    public void PlayBackground(AudioClip ac, float time=0f)
    {
        background.clip = ac;
        background.Play();
        background.time = time;
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
