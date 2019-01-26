using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour, InteractivityObject
{
    public int PressE()
    {
        return (int)GameCtrl.ObjectList.flower;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIInMain.instacne.OnFlowerTrigger();
    }

}
