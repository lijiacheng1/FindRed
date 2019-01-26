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
    private int pressRem;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void ChangeColor(int pressCounter)
    {
        sr.material.color = Color.Lerp(Color.white, colorRed, (float)pressCounter/2);
        pressRem = pressCounter; 
    }
    public int PressE()
    {
        Debug.Log(pressRem);
        if (pressRem == 0)
        {
            riverCollider.SetActive(false);
            ship.SetActive(true);
        }
        if (pressRem == 2)
        {
            leaf.SetActive(true);
        }
        return 0;
    }
}
