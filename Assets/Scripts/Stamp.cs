using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stamp : MonoBehaviour,InteractivityObject {

    public Moon moon;
    private Transform tr;
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Moon>() != null)
        {
            FlyToMoon();
        }
    }
    public int PressE()
    {
        return (int)GameCtrl.ObjectList.Stamp;
    }
    private void FlyToMoon()
    {
        tr.transform.rotation = Quaternion.Euler(0, 0, 270);
        transform.DOPath(new Vector3[] {new Vector3(0.24f, 4.26f,0) }, 2f);
        PlayerController.instance.Release(2);
        moon.Trans();
    }
}
