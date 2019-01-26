using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour,InteractivityObject
{
    public GameObject leaf;
    public GameObject ship;
    public GameObject riverCollider;
    private SpriteRenderer sr;
    private Color colorRed = new Color((float)252/255, (float)96/255, (float)106/255, 1);
    private bool pressRem=false;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void ChangeColor()
    {
        StartCoroutine(ChangeColorIE());
    }
    public int PressE()
    {
        if (pressRem)
        {
            Debug.Log("PressE");
            leaf.SetActive(true);
        }
        if (!pressRem)
        {
            pressRem = true;
            riverCollider.SetActive(false);
            ship.SetActive(true);
        }
        return 0;
    }
    IEnumerator ChangeColorIE()
    {
        for (int i=0;i <= 10; i++)
        {
            sr.color = Color.Lerp(Color.white, colorRed, (float)i / 10);
            yield return new WaitForSeconds(0.1f);
        }

    }
}
