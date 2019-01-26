using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Pickup : MonoBehaviour {
    public Image pickupHint;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null&&collision.GetComponent<PlayerController>().HoldObject!=0)
        {
            pickupHint.gameObject.SetActive(true);
        }
    }
    public virtual int PickupIt()
    {
        return 0;
    }
}
