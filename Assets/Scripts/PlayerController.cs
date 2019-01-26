using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rig;
    SpriteRenderer sr;
    Animator anim;
    [SerializeField]
    Transform handPoint;

    bool isWalking = false;
    bool sleepCryTrigger = false;

    public static PlayerController instance = null;
    //按E的提示
    public Image pressHint;
    //记录手中的物体、是否可以按。速度变量
    public int holdObject;
    private bool canPress = false;
    private Collider2D colliderRem;
    public float speed=1;

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
	
	void Update () {
        var h = Input.GetAxis("Horizontal");
        var v =Input.GetAxis("Vertical");
        if (h!=0 || v!=0)
        {
            if (h > 0)
                sr.flipX = false;
            else
                sr.flipX = true;
            rig.MovePosition((Vector2)transform.position + new Vector2(h * Time.deltaTime*speed, v * Time.deltaTime*speed));
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        //如果CanPress为True，此时可以点击E进行交互
        if (canPress)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                holdObject = colliderRem.GetComponent<InteractivityObject>().PressE();
                if (holdObject != 0)
                {
                    colliderRem.transform.SetParent(handPoint);
                    colliderRem.transform.localPosition = Vector3.zero;
                }
            }
        }
    }

    private void LateUpdate()
    {
        anim.SetBool("isWalking", isWalking);
        if (sleepCryTrigger)
            anim.SetTrigger("sleepCryTrigger");
    }

    //可交互物体碰撞函数，改变CanPress值
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<InteractivityObject>() != null && holdObject == 0)
        {
            canPress = true;
            colliderRem = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canPress = false;
    }
}
