using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {
    public AudioBot _Bot;
    public bool Move = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider Detector) {
        if (Detector.gameObject.tag == "Player") {
            Move = true;
        }
    }
}
