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
    public Image e2;
    public Transform environment;
    public Transform playerCutscene;
    public Transform mask1;
    public Transform mask2;
    public PlayerController player;

    Animator playerCutsceneAnim;
    Animator playerAnim;
    //Animator playerAnim;
    SpriteRenderer[] srs;

    bool canE = false;
    bool canE2 = false;
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
        playerAnim = player.GetComponent<Animator>();

        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].material.DOFade(0, 0);
        }
        title.gameObject.SetActive(false);
        environment.gameObject.SetActive(false);
        wasd.gameObject.SetActive(false);
        e.gameObject.SetActive(false);
        e2.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        playerCutscene.gameObject.SetActive(false);

        Cutscene1();
    }

    public bool test = false;
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
        if (canE2 && Input.GetKeyDown(KeyCode.E))
        {
            canE2 = false;
            SetActiveHide(e2);
            Cutscene3();
        }
        if (test)
        {
            test = false;
            OnFlowerTrigger();
        }
    }

    public void Cutscene1()
    {
        playerCutscene.gameObject.SetActive(true);
        environment.gameObject.SetActive(true);
        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].material.DOFade(1, fadeTime);
        }
        playerCutsceneAnim.SetTrigger("Start");
        mask1.gameObject.SetActive(true);
    }

    public void InputCutScene1()
    {
        SetActiveShow(e);
        canE = true;
    }

    public void Cutscene2()//getup
    {
        playerCutsceneAnim.SetTrigger("GetUp");
    }

    public void InputCutScene2()//get up end
    {
        mask1.gameObject.SetActive(false);
        mask2.gameObject.SetActive(true);
        SetActiveShow(wasd);
        player.gameObject.SetActive(true);
        playerCutscene.gameObject.SetActive(false);
        canWasd = true;
    }


    public void Cutscene3()//title
    {
        playerAnim.SetTrigger("FetchTrigger");
        player.Active = false;
        //player.SetFlipX(false);
        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].material.DOFade(0, fadeTime);
        }
        player.GetComponent<SpriteRenderer>().material.DOFade(0, fadeTime).OnComplete(()=>
        {
            title.DOFade(0, 0).OnComplete(() => {
                title.gameObject.SetActive(true);
                title.DOFade(1, fadeTime);
                GameCtrl.instance.ChangeScene("Level1", 4);
                player.Active = true;
            });
        });
    }

    public void OnFlowerTrigger()
    {
        SetActiveShow(e2);
        canE2 = true;
    }

    public void LoadScene()
    {
        GameCtrl.instance.ChangeScene("Level1", 1);
    }


    void SetActiveShow(Image img)
    {
        img.DOFade(0, 0).OnComplete(()=> img.gameObject.SetActive(true));
        img.DOFade(1, fadeTime);
    }

    void SetActiveHide(Image img)
    {
        img.DOFade(0, fadeTime).OnComplete(() => img.gameObject.SetActive(false));
    }
}

