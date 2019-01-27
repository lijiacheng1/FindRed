using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour,InteractivityObject{
    private float timer;
    private SpriteRenderer sr;
    private Color lucency = new Color(1, 1, 1, 0);
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void Bloom()
    {
        StartCoroutine(ChangeColorIE());
    }
    public int PressE()
    {
        return (int)GameCtrl.ObjectList.Flower;
    }

    IEnumerator ChangeColorIE()
    {
        for (int i = 0; i <= 40; i++)
        {
            sr.color = Color.Lerp(lucency, Color.white, (float)(i / 40));
            yield return new WaitForSeconds(0.1f);
        }
    }
}
