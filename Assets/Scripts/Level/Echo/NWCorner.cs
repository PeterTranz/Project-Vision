using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWCorner : MonoBehaviour {
    public GameObject PushButton1;
    public GameObject PushButton2;

    public GameObject Ramp;

    public GameObject CubeSpawner;

    Animator RampAnim;

	// Use this for initialization
	void Start () {
        RampAnim = Ramp.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        bool Push1 = PushButton1.GetComponent<PushButton>().Pressed;
        bool Push2 = PushButton2.GetComponent<PushButton>().Pressed;

        if (Push1) {
            CubeSpawner.GetComponent<CubeSpawn>().SpawnSentry();
            PushButton1.GetComponent<PushButton>().Pressed = false;
        }

        if (Push2) {
            RampAnim.SetBool("Turn", true);
        }
        if (!Push2) {
            RampAnim.SetBool("Turn", false);
        }
	}
}
