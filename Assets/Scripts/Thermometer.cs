using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour, InteractivityObject
{
    //百叶箱温度变化，改变树
    public Tree tree;
    private Animator anim;
    private bool canPress;
    public SoundCtrl sounds;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Open()
    {
        anim.SetBool("OpenBox", true);
        canPress = true;

    }
    public int PressE()
    {
        if (canPress == true)
        {
            canPress = false;
            tree.ChangeColor();
            GameCtrl.instance.PlayMusic(new Vector3(0, 0, 0), sounds.musicList[6]);
            anim.SetBool("Press", true);
        }
        return 0;
    }
}
