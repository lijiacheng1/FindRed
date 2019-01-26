using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour,InteractivityObject {

    public GameObject moon;
    private Transform tr;
    private float dist;
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    private void Update()
    {
        dist = Vector3.Distance(moon.transform.position, tr.position);
        if (dist <= 1.5)
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

    }
}
