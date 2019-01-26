using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIInMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene()
    {
        GameCtrl.instance.ChangeScene("Level1", 1);
    }
}

