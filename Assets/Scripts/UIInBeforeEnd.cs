using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIInBeforeEnd : MonoBehaviour
{
    public static UIInBeforeEnd instacne;
    public Transform environment;
    public Transform playerCutscene;

    Animator playerCutsceneAnim;
    //Animator playerAnim;
    SpriteRenderer[] srs;

    float fadeTime = 2f;

    private void Awake()
    {
        if (instacne == null)
            instacne = this;
    }
    // Use this for initialization
    void Start()
    {
        srs = environment.GetComponentsInChildren<SpriteRenderer>();
        playerCutsceneAnim = playerCutscene.GetComponent<Animator>();

        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].material.DOFade(0, 0);
        }
        environment.gameObject.SetActive(false);
        playerCutscene.gameObject.SetActive(false);

        Cutscene1();
    }

    void Cutscene1()
    {
        playerCutscene.gameObject.SetActive(true);
        environment.gameObject.SetActive(true);
        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].material.DOFade(1, fadeTime);
        }
        StartCoroutine(Cutscene1a());
    }

    IEnumerator Cutscene1a()
    {
        yield return new WaitForSeconds(1);
        playerCutsceneAnim.SetTrigger("Start");
        yield return new WaitForSeconds(5);
        GameCtrl.instance.ChangeScene("End", 1);
    }
}
