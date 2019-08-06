using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //Player Components
    public PlayerCamera _PlayerCamera;
    public Rigidbody PlayerBody;

    //Movement variables
    private float Speed = 2.5f;
    private bool InAir = false;
    float Forward;
    float Strafe;

    //Game variables
    private bool GamePaused;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GamePaused = false;

        PlayerBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        GamePause();
    }

    //Player movement
    void Movement() {
        if (!GamePaused) {
            #region Player Movement
            if (Input.GetAxis("Forward") != 0) {
                Forward = Speed * Input.GetAxis("Forward");
            }

            else {
                Forward = 0;
            }

            if (Input.GetAxis("Strafe") != 0) {
                Strafe = Speed * Input.GetAxis("Strafe");
            }

            else {
                Strafe = 0;
            }

            Forward *= Time.deltaTime;
            Strafe *= Time.deltaTime;

            transform.Translate(Strafe, 0, Forward);
            #endregion

            #region Player Jump
            if (Input.GetAxis("Jump") != 0) {
                if (!InAir) {
                    this.GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
                    InAir = true;
                }
            }
            #endregion
        }
    }

    //Player pause
    void GamePause() {
        //Paused input
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GamePaused = !GamePaused;

            if (GamePaused == true) {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                Time.timeScale = 0.0f;
                _PlayerCamera.enabled = false;
            }
            else {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1.0f;
                _PlayerCamera.enabled = true;
            }
        }
    }

    void OnCollisionEnter(Collision Player) {
            InAir = false;
    }
}