using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Pickup {
    public override int PickupIt()
    {
        return (int)GameCtrl.ObjectList.Magent;
    }
}
