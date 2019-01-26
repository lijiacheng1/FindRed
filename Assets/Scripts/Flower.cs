using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour/*, InteractivityObject*/
{
    //bool isInit = false;
    //public int PressE()
    //{
    //    return (int)GameCtrl.ObjectList.flower;
    //}

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (isInit)
            UIInMain.instacne.OnFlowerTrigger();
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    isInit = true;
    //}
}
