using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    public Animator Anim;
    public bool Active;

	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Active) {
            Anim.SetBool("Lower", true);
        }
	}
}
