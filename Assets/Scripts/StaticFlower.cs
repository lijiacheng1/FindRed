﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFlower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIInMain.instacne.OnFlowerTrigger(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UIInMain.instacne.OnFlowerTrigger(false);
    }
}
