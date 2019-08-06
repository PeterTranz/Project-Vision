using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator OnCollisionEnter(Collision Block) {
        if (Block.gameObject.tag == "SmashCube") {
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
    }
}
