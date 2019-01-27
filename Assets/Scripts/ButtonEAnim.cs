using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonEAnim : MonoBehaviour {
    Image img;
    float fadeTime = 2;


    public void Start()
    {
        img = GetComponent<Image>();
    }
    // Use this for initialization
    void OnEnable () {
	}
	
	// Update is called once per frame
	void OnDisable () {
		
	}

    public void Show()
    {
        img.DOFade(0, 0).OnComplete(() => img.gameObject.SetActive(true));
        img.DOFade(1, fadeTime);
    }

    public void Hide()
    {
        img.DOFade(0, fadeTime).OnComplete(() => img.gameObject.SetActive(false));
    }
}
