using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWall : MonoBehaviour {
    //Generators
    public GameObject Gen1;
    public GameObject Gen2;
    public GameObject Gen3;
    public GameObject Gen4;

    //Animator
    public Animator SecondWallDoors;

	// Use this for initialization
	void Start () {
        SecondWallDoors = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //Generators update
        bool Gen1Stat = Gen1.GetComponent<PowerGen>().Charged;
        bool Gen2Stat = Gen2.GetComponent<PowerGen>().Charged;
        bool Gen3Stat = Gen3.GetComponent<PowerGen>().Charged;
        bool Gen4Stat = Gen4.GetComponent<PowerGen>().Charged;

        //Checks if they are charged
        if (Gen1Stat && Gen2Stat && Gen3Stat && Gen4Stat) {
            //Animate the door to open
            SecondWallDoors.SetBool("Open", true);
        }
	}
}
