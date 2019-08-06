using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingStick : MonoBehaviour {
    //Controller variables
    public bool HapticVib = false;

    //Player variables
    float Forward = 0;
    float Strafe = 0;
    public float Speed;
    public GameObject PlayerHead;

    //Steam vr device
    private SteamVR_TrackedObject TrackedObj;
    private SteamVR_Controller.Device Controls { get { return SteamVR_Controller.Input((int)TrackedObj.index); } }

    //Steam vr inputs
    private Valve.VR.EVRButtonId TriggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    // Use this for initialization
    void Awake () {
        TrackedObj = GetComponent<SteamVR_TrackedObject>();
    }
	
	// Update is called once per frame
	void Update () {
        if (HapticVib) {
            Controls.TriggerHapticPulse(900);
        }


        #region Player Movement
        if (Controls.GetPressDown(TriggerButton)) {
            Forward = Speed * Time.deltaTime;
        }

        if (Controls.GetPressUp(TriggerButton)) {
            Forward = 0;
        }

        Debug.Log(Forward);
        PlayerHead.transform.Translate(0.0f, 0.0f, Forward);
        #endregion
    }

    //Tigger collision
    void OnTriggerStay(Collider Stick) {
        if (Stick.gameObject.tag == "Wall") {
            HapticVib = true;
        }
    }

    void OnTriggerExit(Collider Stick) {
        HapticVib = false;
    }
}
