using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance = null;

    Rigidbody2D rig;
    SpriteRenderer sr;
    Animator anim;

    bool isWalking = false;
    bool sleepCryTrigger = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start () {
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        var h = Input.GetAxis("Horizontal");
        var v =Input.GetAxis("Vertical");
        if (h!=0 || v!=0)
        {
            if (h > 0)
                sr.flipX = false;
            else
                sr.flipX = true;
            rig.MovePosition((Vector2)transform.position + new Vector2(h * Time.deltaTime, v * Time.deltaTime));
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void LateUpdate()
    {
        anim.SetBool("isWalking", isWalking);
        if (sleepCryTrigger)
            anim.SetTrigger("sleepCryTrigger");
    }
}
