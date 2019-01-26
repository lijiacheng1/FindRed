﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour {
    //实现白色遮挡的图片
    private Image mask;
    //单例模式
    public static GameCtrl instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
       mask = this.transform.Find("Canvas/Mask").gameObject.GetComponent<Image>();
    }
    public void ChangeScene(string sceneName,float time)
    {
        StartCoroutine(ChangeSceneAnim(sceneName, time));
    }

    //闪烁白光，同时加载场景,第一个参数为加载的场景名，第二个参数为白光闪烁的时间，总时间为*2
    IEnumerator ChangeSceneAnim(string sceneName,float time)
    {
        this.transform.Find("Canvas").gameObject.SetActive(true);
        var color1 = new Color(1f, 1f, 1f, 0);
        var color2 = new Color(1f, 1f, 1f, 1f);
        for (float f = 0;f<= time;f += 0.05f)
        {
            mask.color = Color.Lerp(color1, color2, f/time);
            yield return new WaitForSeconds(0.05f);
        }
        SceneManager.LoadScene(sceneName);
        for (float f = 0; f <= time; f += 0.05f)
        {
            mask.color = Color.Lerp(color2, color1, f / time);
            yield return new WaitForSeconds(0.05f);
        }
        this.transform.Find("Canvas").gameObject.SetActive(false);
    }
}