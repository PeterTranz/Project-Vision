using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorCam : MonoBehaviour {
    //Spectator Camera Variables
    [SerializeField]
    float CameraSpeed;

    [SerializeField]
    float Sensitivity = 5.0f;

    [SerializeField]
    float Smoothing = 2.0f;

    float Forward;
    float Strafe;
    float Vertical;
    Vector2 MouseLook;
    Vector2 SmoothV;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CameraLook();
        CameraMove();
	}

    //Camera look
    void CameraLook() {
        var Mouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        Mouse = Vector2.Scale(Mouse, new Vector2(Sensitivity * Smoothing, Sensitivity * Smoothing));
        SmoothV.x = Mathf.Lerp(SmoothV.x, Mouse.x, 1.0f / Smoothing);
        SmoothV.y = Mathf.Lerp(SmoothV.y, Mouse.y, 1.0f / Smoothing);
        MouseLook += SmoothV;
        MouseLook.y = Mathf.Clamp(MouseLook.y, -80, 80);

        transform.localRotation = Quaternion.Euler(-MouseLook.y, MouseLook.x, 0);
    }

    //Moving the camera
    void CameraMove() {
        if (Input.GetAxis("Forward") != 0) {
            Forward = CameraSpeed * Time.deltaTime * Input.GetAxis("Forward");
        }
        else {
            Forward = 0;
        }

        if (Input.GetAxis("Strafe") != 0) {
            Strafe = CameraSpeed * Time.deltaTime * Input.GetAxis("Strafe");
        }
        else {
            Strafe = 0;
        }

        this.transform.Translate(Strafe, 0, Forward);
    }
}
