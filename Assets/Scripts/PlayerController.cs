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
    bool active = true;

    public static PlayerController instance = null;
    //按E的提示
    public ButtonEAnim pressHint;
    //记录手中的物体、是否可以按。速度变量
    public int holdObject;
    private bool canPress = false;
    private Collider2D colliderRem;

    public float speed = 5;

    public bool Active
    {
        get
        {
            return active;
        }

        set
        {
            active = value;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Active)
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            if (h != 0 || v != 0)
            {
                if (h > 0)
                {
                    sr.flipX = false;
                    handPoint.localPosition = new Vector3(1.37f, 0, 0);
                }
                else if (h < 0)
                {
                    sr.flipX = true;
                    handPoint.localPosition = new Vector3(-1.37f, 0, 0);
                }
                rig.MovePosition((Vector2)transform.position + new Vector2(h * speed *Time.deltaTime, v *speed* Time.deltaTime));
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
                        anim.SetTrigger("FetchTrigger2");
                        canPress = false;
                        pressHint.Hide();
                        colliderRem.transform.SetParent(handPoint);
                        colliderRem.transform.localPosition = Vector3.zero;
                    }
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
            pressHint.Show();
            canPress = true;
            colliderRem = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canPress = false;
        pressHint.Hide();
    }
    //放下物品函数
    public void Release(float time)
    {
        holdObject = 0;
        if(handPoint.transform.GetChild(0) != null)
        {
            Destroy(handPoint.transform.GetChild(0).gameObject, time);
        }
    }

    public void SetFlipX(bool isLeft)
    {
        sr.flipX = isLeft;
    }
}
