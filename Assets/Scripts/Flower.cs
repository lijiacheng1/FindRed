using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour,InteractivityObject{

    public int PressE()
    {
        return (int)GameCtrl.ObjectList.Flower;
    }
}
