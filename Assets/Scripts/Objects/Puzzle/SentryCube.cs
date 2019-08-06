using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryCube : MonoBehaviour {
    private GameObject _SentryCube;
    private GameObject Parent;

    // Use this for initialization
    void Start() {
        _SentryCube = this.gameObject;
        _SentryCube.GetComponent<Rigidbody>().useGravity = true;
        Parent = GameObject.Find("Guide");
    }

    // Update is called once per frame
    void Update() {

    }

    //When the mouse hovers over the object
    void OnMouseDown() {
        _SentryCube.GetComponent<Rigidbody>().useGravity = false;
        _SentryCube.GetComponent<Rigidbody>().isKinematic = true;
        _SentryCube.transform.position = Parent.transform.position;
        _SentryCube.transform.rotation = Parent.transform.rotation;
        _SentryCube.transform.parent = Parent.transform;
    }

    //Mouse release
    private void OnMouseUp() {
        _SentryCube.GetComponent<Rigidbody>().useGravity = true;
        _SentryCube.GetComponent<Rigidbody>().isKinematic = false;
        _SentryCube.transform.position = Parent.transform.position;
        _SentryCube.transform.parent = null;
    }

    void OnCollisionEnter(Collision Cube) {
        if (Cube.gameObject.tag == "Nope") {
            Destroy(this.gameObject);
        }
    }
}
