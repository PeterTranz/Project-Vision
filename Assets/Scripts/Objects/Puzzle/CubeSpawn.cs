using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour {
    //Objects to spawn
    public GameObject SentryCube;
    public GameObject PowerCube;
    public GameObject SmashCube;
    public GameObject EasterEgg;

    //Copies of spawn objects
    private GameObject SentryCubeCopy;
    private GameObject PowerCubeCopy;
    private GameObject SmashCubeCopy;
    private GameObject EasterCopy;

    //bool to spawn at start of game
    public bool Spawn_SentryCube;
    public bool Spawn_PowerCube;
    public bool Spawn_SmashCube;

    // Use this for initialization
    void Start () {
        if (Spawn_SentryCube) {
            SpawnSentry();
        }

        if (Spawn_PowerCube) {
            SpawnPower();
        }

        if (Spawn_SmashCube) {
            SpawnSmash();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPower() {
        PowerCubeCopy = Instantiate(PowerCube, this.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    public void SpawnSentry() {
        SentryCubeCopy = Instantiate(SentryCube, this.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    public void SpawnSmash() {
        SmashCubeCopy = Instantiate(SmashCube, this.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    public void SpawnEgg() {
        EasterCopy = Instantiate(EasterEgg, this.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        Destroy(EasterCopy, 5);
    }
}
