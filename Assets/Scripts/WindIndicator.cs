using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WindIndicator : MonoBehaviour
{
    //本身位置、magnetMan位置
    private Transform tr;
    public Transform magnetTr;
    private GameObject image;

    private void Start()
    {
        image = this.gameObject;
        magnetTr = GameObject.FindWithTag("MagnetMan").transform;
        tr = GetComponent<Transform>();
    }
    private void Update()
    {
        var imageRot = magnetTr.position - tr.position;
        var rotAngle = Math.Atan(imageRot.y / imageRot.x);
        var transformation = (float)(1 / (1 + 2 * Math.Abs(Math.Sin(rotAngle))));
        image.transform.localScale = new Vector3(transformation, 1, 1);
        if (imageRot.x >= 0)
        {
            image.transform.rotation = Quaternion.Euler(0, 0, (float)(rotAngle / Math.PI) * 180 + 180);
        }
        else
        {
            image.transform.rotation = Quaternion.Euler(0, 0, (float)(rotAngle / Math.PI) * 180);
        }
    }
}
