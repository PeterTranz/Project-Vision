using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCube : MonoBehaviour {
    private GameObject Key;
    private bool Placed;

    //Pick up
    private GameObject _PowerCube;
    private GameObject Parent;

    // Use this for initialization
    void Start () {
        _PowerCube = this.gameObject;
        Parent = GameObject.Find("Guide");
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    //When the mouse hovers over the object
    void OnMouseDown() {
        _PowerCube.GetComponent<Rigidbody>().useGravity = false;
        _PowerCube.GetComponent<Rigidbody>().isKinematic = true;
        _PowerCube.transform.position = Parent.transform.position;
        _PowerCube.transform.rotation = Parent.transform.rotation;
        _PowerCube.transform.parent = Parent.transform;
    }

    //Mouse release
    private void OnMouseUp() {
        _PowerCube.GetComponent<Rigidbody>().useGravity = true;
        _PowerCube.GetComponent<Rigidbody>().isKinematic = false;
        _PowerCube.transform.position = Parent.transform.position;
        _PowerCube.transform.parent = null;
    }

    void OnCollisionEnter(Collision Cube) {
        if (Cube.gameObject.tag == "Nope") {
            Destroy(this.gameObject);
        }
    }
}
