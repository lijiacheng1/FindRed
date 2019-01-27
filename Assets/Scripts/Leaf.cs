using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour, InteractivityObject
{
    public int PressE()
    {
        return (int)GameCtrl.ObjectList.Leaf;
    }
}
