using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouthPuzzle : MonoBehaviour {
    public GameObject PushButton;
    public GameObject BlockedButton1;
    public GameObject BlockedButton2;
    public GameObject BlockedButton3;
    public GameObject BlockedButton4;

    public GameObject EasterSpawn;
    public GameObject Spawn1;
    public GameObject Spawn2;

    bool solved = false;
    bool _BB1;
    bool _BB2;
    bool _BB3;
    bool _BB4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _BB1 = BlockedButton1.GetComponent<Button>().Active;
        _BB2 = BlockedButton2.GetComponent<Button>().Active;
        _BB3 = BlockedButton3.GetComponent<Button>().Active;
        _BB4 = BlockedButton4.GetComponent<Button>().Active;

        if (_BB1 && _BB2 && _BB3 && _BB4) {
            solved = true;
        }


        if (!solved) {
            if (PushButton.GetComponent<PushButton>().Pressed) {
                EasterSpawn.GetComponent<CubeSpawn>().SpawnEgg();
                PushButton.GetComponent<PushButton>().Pressed = false;
            }
        }

        if (solved) {
            if (PushButton.GetComponent<PushButton>().Pressed) {
                Spawn1.GetComponent<CubeSpawn>().SpawnSentry();
                Spawn2.GetComponent<CubeSpawn>().SpawnSentry();
                PushButton.GetComponent<PushButton>().Pressed = false;
            }
        }
    }
}