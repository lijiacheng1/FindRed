using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour {
    //百叶窗
    public Thermometer thermometer;
    //自身位置，磁铁人位置，是否开始旋转
    private Transform tr;
    private Transform magnetTr;
    private bool rotate = false;

    private float timer;
    private float cycle=1;
    private void Start()
    {
        tr = GetComponent<Transform>();
        magnetTr = GameObject.FindWithTag("MagnetMan").transform;
    }
    private void Update()
    {
        if(magnetTr.position == new Vector3(0, 0, 0))
        {
            rotate = true;
        }
        if(rotate == true)
        {
            timer += Time.deltaTime;
            tr.rotation = Quaternion.Euler(0, 0, (timer%cycle/cycle)*360);
            thermometer.Open();
        }
    }
}
