using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour {
    public bool Pressed;
    public bool toggle = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter(Collision Push) {
        if (Push.gameObject.tag == "PushButton") {
            if (toggle) {
                doubleClick();
            }
            if (!toggle) {
                Pressed = true;
            }
        }
    }

    void doubleClick(){
        Pressed = !Pressed;
    }
}
