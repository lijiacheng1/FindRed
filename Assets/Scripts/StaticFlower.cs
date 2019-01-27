using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFlower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogError(111);
        if (collision.gameObject.tag.Equals("Player"))
        {
            //Debug.LogError(222);
            UIInMain.instacne.OnFlowerTrigger(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            UIInMain.instacne.OnFlowerTrigger(false);
    }
}
