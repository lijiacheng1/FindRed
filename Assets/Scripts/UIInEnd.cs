using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIInEnd : MonoBehaviour {

    public static UIInEnd instacne;
    public Image title;
    public Transform environment;
    public Transform playerCutscene;
    public Transform mask1;
    public AudioClip back;
    //public Transform flower;

    Animator playerCutsceneAnim;
    Animator playerAnim;
    //Animator playerAnim;
    SpriteRenderer[] srs;

    float fadeTime = 2f;

    private void Awake()
    {
        if (instacne == null)
            instacne = this;
    }
    // Use this for initialization
    void Start () {

        srs = environment.GetComponentsInChildren<SpriteRenderer>();
        playerCutsceneAnim = playerCutscene.GetComponent<Animator>();

        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].material.DOFade(0, 0);
        }
        title.gameObject.SetActive(false);
        environment.gameObject.SetActive(false);
        //flower.gameObject.SetActive(false);
        playerCutscene.gameObject.SetActive(false);

        Cutscene1();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Cutscene1()
    {
        playerCutscene.gameObject.SetActive(true);
        environment.gameObject.SetActive(true);
        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].material.DOFade(1, fadeTime);
        }
        mask1.gameObject.SetActive(true);
        StartCoroutine(Cutscene1a());
    }

    IEnumerator Cutscene1a()
    {
        yield return new WaitForSeconds(2);
        playerCutsceneAnim.SetTrigger("Start");
        AudioController.instance.PlayBackground(back);
        yield return new WaitForSeconds(5);
        Cutscene2();
    }

    public void Cutscene2()//title
    {
        mask1.gameObject.SetActive(false);
        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].material.DOFade(0, fadeTime);
        }
        title.DOFade(0.3f, 0).OnComplete(() => {
            title.gameObject.SetActive(true);
            title.DOFade(1, fadeTime);
        });
    }
}
