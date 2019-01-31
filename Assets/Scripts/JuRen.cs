using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuRen : MonoBehaviour {
    private Animator anim;
    public SpriteRenderer eye;
    public SoundCtrl sounds;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        var vct3Rem = PlayerController.instance.transform.position - eye.transform.position;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null&&PlayerController.instance.holdObject == (int)GameCtrl.ObjectList.Flower)
        {
            GameCtrl.instance.PlayMusic(new Vector3(0, 0, 0), sounds.musicList[1]);
            anim.SetBool("Sneeze", true);
            StartCoroutine(ChangeScene());
        }
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(4f);
        GameCtrl.instance.ChangeScene("ShuYe", 1f);
    }
}
