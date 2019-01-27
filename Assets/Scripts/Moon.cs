using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {
    private Animator anim;
    public Flower flower;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Trans()
    {
        StartCoroutine(TransTrue());
    }
    IEnumerator TransTrue()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("Trans", true);
        yield return new WaitForSeconds(2f);
        flower.gameObject.SetActive(true);
        flower.Bloom();
        yield return new WaitForSeconds(4f);
        anim.SetBool("Trans", false);
    }
}
