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
    private bool run;
    public Vector3[] runPath= {new Vector3(0.7371982f, 1.076728f,0),new Vector3(-0.5184425f, 1.808175f,0),new Vector3(-3.834565f, -0.9172503f,0)};
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
            if (run == false)
            {
                run = true;
                anim.SetBool("Run", true);
                RunAway();
            }
        }
        if (tr.position == runPath[runPath.Length-1])
        {
            anim.SetBool("Run", false);
        }
    }
    private void RunAway()
    {
        transform.DOPath(runPath,5f);
    }
}
