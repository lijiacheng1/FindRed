using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuRen : MonoBehaviour {
    private Animator anim;
    public SpriteRenderer eye;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    { 
        //= PlayerController.instance.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null&&PlayerController.instance.holdObject == (int)GameCtrl.ObjectList.Flower)
        {
            anim.SetBool("Sneeze", true);
        }
    }
}
