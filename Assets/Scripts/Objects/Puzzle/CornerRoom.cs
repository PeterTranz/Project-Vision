using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerRoom : MonoBehaviour {
    public GameObject Button;
    public Animator Doors;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool Open = Button.GetComponent<Button>().Active;

        if (Open) {
            Doors.SetBool("Open", true);
        }
        else {
            Doors.SetBool("Open", false);
        }
	}
}