using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Pickup : MonoBehaviour {
    public Image pickupHint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null&&collision.GetComponent<PlayerController>().holdObject ==0)
        {
            pickupHint.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            pickupHint.gameObject.SetActive(false);
        }
    }
    public virtual int PickupIt()
    {
        return 0;
    }
}
