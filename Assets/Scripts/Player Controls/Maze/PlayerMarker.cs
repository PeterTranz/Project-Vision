using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarker : MonoBehaviour {
    [SerializeField]
    float RotateSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
	}
}
