using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {
    private Animator anim;
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
        yield return new WaitForSeconds(2f);
        anim.SetBool("Trans", true);
    }
}
