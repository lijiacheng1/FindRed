using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIInMain : MonoBehaviour {
    public static UIInMain instacne;
    public Image title;
    public Image wasd;
    public Image e;
    public Transform environment;
    public Transform playerCutscene;
    public Transform player;

    Animator playerCutsceneAnim;
    //Animator playerAnim;
    SpriteRenderer[] srs;

    bool canE = false;
    bool canWasd = false;
    float fadeTime = 2f;

    private void Awake()
    {
        if (instacne == null)
            instacne = this;
    }

    // Use this for initialization
    void Start ()
    {
        srs = environment.GetComponentsInChildren<SpriteRenderer>();
        playerCutsceneAnim = playerCutscene.GetComponent<Animator>();
        //playerAnim = player.GetComponent<Animator>();

        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].material.DOFade(0, 0);
        }
        title.gameObject.SetActive(false);
        environment.gameObject.SetActive(false);
        wasd.gameObject.SetActive(false);
        e.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        playerCutscene.gameObject.SetActive(true);

        Cutscene1();
    }

    // Update is called once per frame
    void Update () {
        if (canE && Input.GetKeyDown(KeyCode.E))
        {
            canE = false;
            SetActiveHide(e);
            Cutscene2();
        }
        if (canWasd && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            canWasd = false;
            SetActiveHide(wasd);
            //Cutscene3();
        }
    }

    public void Cutscene1()
    {
        title.DOFade(0, fadeTime);
        environment.gameObject.SetActive(true);
        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].material.DOFade(1, fadeTime);
        }
        playerCutsceneAnim.SetTrigger("Start");
    }

    public void InputCutScene1()
    {
        SetActiveShow(e);
        canE = true;
    }

    public void Cutscene2()
    {
        playerCutsceneAnim.SetTrigger("GetUp");
    }

    public void InputCutScene2()//get up end
    {
        SetActiveShow(wasd);
        player.gameObject.SetActive(true);
        playerCutscene.gameObject.SetActive(false);
        canWasd = true;
    }

    public void Cutscene3()
    {
    }

    public void LoadScene()
    {
        GameCtrl.instance.ChangeScene("Level1", 1);
    }


    public void SetActiveShow(Image img)
    {
        img.DOFade(0, 0).OnComplete(()=> img.gameObject.SetActive(true));
        img.DOFade(1, fadeTime);
    }

    public void SetActiveHide(Image img)
    {
        img.DOFade(0, fadeTime).OnComplete(() => img.gameObject.SetActive(false));
    }

}

