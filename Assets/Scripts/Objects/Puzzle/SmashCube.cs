using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashCube : MonoBehaviour {
    private GameObject _SmashCube;
    private GameObject Parent;

    // Use this for initialization
    void Start() {
        _SmashCube = this.gameObject;
        _SmashCube.GetComponent<Rigidbody>().useGravity = true;
        Parent = GameObject.Find("Guide");
    }

    // Update is called once per frame
    void Update() {

    }

    //When the mouse hovers over the object
    void OnMouseDown() {
        _SmashCube.GetComponent<Rigidbody>().useGravity = false;
        _SmashCube.GetComponent<Rigidbody>().isKinematic = true;
        _SmashCube.transform.position = Parent.transform.position;
        _SmashCube.transform.rotation = Parent.transform.rotation;
        _SmashCube.transform.parent = Parent.transform;
    }

    //Mouse release
    private void OnMouseUp() {
        _SmashCube.GetComponent<Rigidbody>().useGravity = true;
        _SmashCube.GetComponent<Rigidbody>().isKinematic = false;
        _SmashCube.transform.position = Parent.transform.position;
        _SmashCube.transform.parent = null;
    }

    void OnCollisionEnter(Collision Cube) {
        if (Cube.gameObject.tag == "Nope") {
            Destroy(this.gameObject);
        }
    }
}
