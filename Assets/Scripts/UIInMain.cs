using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIInMain : MonoBehaviour {

    public Image title;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Cutscene()
    {
        title.DOFade(0, 1);
    }

    public void LoadScene()
    {
        GameCtrl.instance.ChangeScene("Level1", 1);
    }
}

