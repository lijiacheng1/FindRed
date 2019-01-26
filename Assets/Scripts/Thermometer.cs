using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour, InteractivityObject
{
    //
    public Tree tree;
    private Animator anim;
    private int pressCounter=0;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Open()
    {
        anim.SetBool("OpenBox", true);
    }
    public int PressE()
    {
        if (pressCounter <= 2)
        {
            pressCounter += 1;
            tree.ChangeColor(pressCounter);
        }
        anim.SetInteger("PressCounter", pressCounter);
        return 0;
    }
}
