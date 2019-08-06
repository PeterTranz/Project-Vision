using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGen : MonoBehaviour {
    public bool Charged;
    private bool Placed;
    public GameObject PowerCore;
    private GameObject PowerCopy;

    public GameObject Generator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Charged && !Placed) {
            PowerCopy = Instantiate(PowerCore, Generator.transform.position, Quaternion.Euler(0, 0, 0));
            PowerCopy.GetComponent<Rigidbody>().useGravity = false;
            PowerCopy.GetComponent<Rigidbody>().isKinematic = true;
            Placed = true;
        }
	}

    void OnTriggerEnter(Collider Gen) {
        if (!Charged) {
            if (Gen.tag == "PowerCube") {
                Destroy(Gen.gameObject);
                Charged = true;
            }
        }
    }
}
