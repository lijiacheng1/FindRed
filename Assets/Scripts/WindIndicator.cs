using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneObject : MonoBehaviour {
    //本身位置、玩家位置
    private Transform tr;
    private Transform playerTr;
    public GameObject image;

    private void Start()
    {
        playerTr = PlayerController.instance.GetComponent<Transform>();
        tr = GetComponent<Transform>();
    }
    private void Update()
    {
        var imageRot = playerTr.position - tr.position;
        var rotAngle = Math.Atan(imageRot.y / imageRot.x);
        image.transform.rotation = Quaternion.Euler(0,(float)(rotAngle/Math.PI)*180, (float)(rotAngle / Math.PI) * 180);
        Debug.Log(imageRot);
    }
}
