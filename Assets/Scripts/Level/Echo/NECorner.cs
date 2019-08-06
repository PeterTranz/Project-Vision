using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NECorner : MonoBehaviour {
    public GameObject CubeSpawn;
    public GameObject _PushButton;
    public GameObject Block1;
    public GameObject Block2;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    bool puzzleBut;
    bool _Button1;
    bool _Button2;
    bool Spawned = false;
    Animator Anim1;
    Animator Anim2;

    public GameObject Hidden1;
    public GameObject Hidden2;

	// Use this for initialization
	void Start () {
        Anim1 = Block1.GetComponent<Animator>();
        Anim2 = Block2.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        _Button1 = Button1.GetComponent<Button>().Active;
        _Button2 = Button2.GetComponent<Button>().Active;
        puzzleBut = Button3.GetComponent<Button>().Active;

        if (!puzzleBut) {
            if (_PushButton.GetComponent<PushButton>().Pressed) {
                CubeSpawn.GetComponent<CubeSpawn>().SpawnSentry();
                _PushButton.GetComponent<PushButton>().Pressed = false;
            }
        }

        if (puzzleBut) {
            Hidden1.GetComponent<Animator>().SetBool("Down", true);
            Hidden2.GetComponent<Animator>().SetBool("Down", true);
        }

        if (_Button1) {
            Anim1.SetBool("Release", true);
        }

        if (_Button2) {
            Anim2.SetBool("Release", true);
        }
	}
}
