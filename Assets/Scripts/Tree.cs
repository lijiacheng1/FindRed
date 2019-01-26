using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tree : MonoBehaviour,InteractivityObject
{
    public GameObject leaf;
    public GameObject ship;
    public GameObject riverCollider;
    private SpriteRenderer sr;
    private Color colorRed = new Color((float)252/255, (float)96/255, (float)106/255, 1);
    private bool pressRem=false;

    public SoundCtrl sounds;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void ChangeColor()
    {
        StartCoroutine(ChangeColorIE());
        GameCtrl.instance.PlayMusic(new Vector3(0,0,0), sounds.musicList[1]);
        pressRem = true;
    }
    public int PressE()
    {
        if (pressRem)
        {
            leaf.SetActive(true);
            Vector3[] runPath = { new Vector3(0, 0, 0) };
            leaf.transform.DOPath(runPath, 2f);
        }
        if (!pressRem)
        {
            riverCollider.SetActive(false);
            ship.SetActive(true);
            Vector3[] runPath = { new Vector3(0, 0, 0) };
            GameCtrl.instance.PlayMusic(new Vector3(0,0,0), sounds.musicList[5]);
            ship.transform.DOPath(runPath, 2f);
        }
        return 0;
    }
    IEnumerator ChangeColorIE()
    {
        for (int i=0;i <= 20; i++)
        {
            sr.color = Color.Lerp(Color.white, colorRed, (float)i / 20);
            yield return new WaitForSeconds(0.1f);
        }

    }
}
