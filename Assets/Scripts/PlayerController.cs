using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rig;
    SpriteRenderer sr;
    Animator anim;
    bool isWalking = false;

    //trigger
    bool sleepCryTrigger = false;

    public static PlayerController instance = null;
    public int HoldObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
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
