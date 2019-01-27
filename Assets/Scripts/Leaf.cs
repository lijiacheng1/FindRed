using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour, InteractivityObject
{
    public int PressE()
    {
        GameCtrl.instance.ChangeScene("BeforeEnd1", 1f);
        return (int)GameCtrl.ObjectList.Leaf;
    }
}
