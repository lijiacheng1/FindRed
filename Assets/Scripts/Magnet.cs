using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Magnet : MonoBehaviour{
    //获取玩家位置、本身位置、二者距离、自身动画控制器
    private Transform playTr;
    private Transform tr;
    private float dist;
    private Animator anim;
    //判断是否已经跑到目的地了
    private bool runEnd;
    private bool running;
    private int runIndex=0;
    //
    public SoundCtrl sounds;
    public Vector3[] runPath= new Vector3[5]{new Vector3(0, 0, 0), new Vector3(3.57f, -1.5f, 0),new Vector3(-0.98f, 1.04f, 0), new Vector3(-2.31f, 0.66f, 0), new Vector3(-3.834565f, -0.9172503f,0)};
    private void Start()
    {
        playTr = PlayerController.instance.GetComponent<Transform>();
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        dist = Vector3.Distance(tr.position, playTr.position);
        
        if (dist <= 1)
        {
            if (runEnd == false && !running)
            {
                if (runIndex == runPath.Length - 1)
                {
                    runEnd = true;
                }
                if (runIndex < runPath.Length)
                {
                    running = true;
                    anim.SetBool("Run", true);
                    RunAway();
                }
            }
        }
        if (tr.position == runPath[runIndex])
        {
            running = false;
            anim.SetBool("Run", false);
        }
    }
    private void RunAway()
    {
        runIndex += 1;
        transform.DOPath(new Vector3[] { runPath[runIndex]},3f);
        GameCtrl.instance.PlayMusic(new Vector3(0, 0, 0), sounds.musicList[3]);
    }
}
