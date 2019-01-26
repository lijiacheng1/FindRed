using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
    private SpriteRenderer sr;
    private Color colorRed = new Color(252, 96, 106, 255);
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void ChangeColor(int pressCounter)
    {
        sr.color = Color.Lerp(Color.white, colorRed, 1);
    }
}
