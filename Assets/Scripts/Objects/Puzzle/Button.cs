using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    public Animator ButtonAnimation;
    public bool Active;

    // Use this for initialization
    void Start () {
        ButtonAnimation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Trigger collider
    void OnTriggerEnter(Collider Obj) {
        if (Obj.gameObject.tag == "SentryCube") {
            ButtonAnimation.SetBool("Pressed", true);
            Active = true;
        }
    }

    void OnTriggerExit(Collider Obj) {
        if (Obj.gameObject.tag == "SentryCube")
        {
            ButtonAnimation.SetBool("Pressed", false);
            Active = false;
        }
    }
}
