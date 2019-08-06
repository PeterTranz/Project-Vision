using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    Vector2 MouseLook;
    Vector2 SmoothV;
    private float Sensitivity = 5.0f;
    private float Smoothing = 2.0f;

    GameObject Player;

	// Use this for initialization
	void Start () {
        Player = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        var Mouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        Mouse = Vector2.Scale(Mouse, new Vector2(Sensitivity * Smoothing, Sensitivity * Smoothing));
        SmoothV.x = Mathf.Lerp(SmoothV.x, Mouse.x, 1.0f / Smoothing);
        SmoothV.y = Mathf.Lerp(SmoothV.y, Mouse.y, 1.0f / Smoothing);
        MouseLook += SmoothV;
        MouseLook.y = Mathf.Clamp(MouseLook.y, -80.0f, 80.0f);

        transform.localRotation = Quaternion.AngleAxis(-MouseLook.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(MouseLook.x, Player.transform.up);
	}
}
