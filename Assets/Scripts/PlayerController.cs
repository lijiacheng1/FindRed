using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rig;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        var h = Input.GetAxis("Horizontal");
        var v =Input.GetAxis("Vertical");
        rig.MovePosition((Vector2)transform.position + new Vector2(h * Time.deltaTime,v * Time.deltaTime));
    }
}
