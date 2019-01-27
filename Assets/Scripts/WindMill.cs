using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour {
    //百叶窗
    public Thermometer thermometer;
    //自身位置，磁铁人位置，是否开始旋转
    private Transform tr;
    public Magnet magnetMan;
    private Transform magnetTr;
    private bool rotate = false;
    private bool playSound = false;
    public SoundCtrl sounds;
    private float timer;
    private float cycle=1;
    private bool opened = false;
    private void Start()
    {
        tr = GetComponent<Transform>();
        magnetTr = GameObject.FindWithTag("MagnetMan").transform;
    }
    private void Update()
    {
        if(magnetTr.position == magnetMan.runPath[magnetMan.runPath.Length-1])
        {
            rotate = true;
            if (!playSound)
            {
                GameCtrl.instance.PlayMusic(new Vector3(0, 0, 0), sounds.musicList[8]);
                playSound = true;
            }
        }
        if(rotate == true)
        {
            timer += Time.deltaTime;
            tr.rotation = Quaternion.Euler(0, 0, (timer%cycle/cycle)*360);
            if (!opened)
            {
                thermometer.Open();
                opened = true;
            }
        }
    }
}
