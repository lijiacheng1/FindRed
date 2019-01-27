using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour {

    public enum ObjectList
    {
        Null,
        Magent,
        Flower,
        Stamp,
        Leaf,
    }
    //实现白色遮挡的图片
    private Image mask;
    //单例模式
    public static GameCtrl instance = null;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
       mask = this.transform.Find("Canvas/Mask").gameObject.GetComponent<Image>();
    }
    public void ChangeScene(string sceneName,float time)
    {
        StartCoroutine(ChangeSceneAnim(sceneName, time));
    }
    //播放音乐
    public void PlayMusic(Vector3 pos, AudioClip music)
    {
        GameObject soundObj = new GameObject("Music");
        soundObj.transform.position = pos;
        AudioSource audiosource = soundObj.AddComponent<AudioSource>();
        audiosource.clip = music;
        audiosource.Play();
        Destroy(soundObj, music.length);
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
        PlayerController.instance.Release(0.1f);
        this.transform.Find("Canvas").gameObject.SetActive(false);
    }
}
