using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveInput : MonoBehaviour {

    //Steam vr inputs
    private Valve.VR.EVRButtonId TriggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId TouchButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

    //Steam vr device
    private SteamVR_TrackedObject TrackedObj;
    private SteamVR_Controller.Device Controls { get { return SteamVR_Controller.Input((int)TrackedObj.index); } }

    //Game object
    public GameObject Player;
    private GameObject PickUpObject;
    private GameObject Parent;

    //Teleport variables
    Ray _Ray;
    RaycastHit Hit;
    private bool Ground;
    private Vector3 NewLocation;

    public GameObject TeleportMarker;
    private GameObject TeleportArea;

    // Use this for initialization
    void Awake() {
        TrackedObj = GetComponent<SteamVR_TrackedObject>();
        Parent = this.gameObject;
    }

    // Update is called once per frame
    void Update() {
        //Pick up and drop
        #region Trigger Input
        //Trigger Down
        if (Controls.GetPressDown(TriggerButton) && PickUpObject != null) {
            PickUpObject.GetComponent<Rigidbody>().isKinematic = true;
            PickUpObject.GetComponent<Rigidbody>().useGravity = false;
            PickUpObject.transform.position = Parent.transform.position;
            PickUpObject.transform.rotation = Parent.transform.rotation;
            PickUpObject.transform.parent = Parent.transform;
        }

        //Trigger Up
        if (Controls.GetPressUp(TriggerButton) && PickUpObject != null) {
            PickUpObject.GetComponent<Rigidbody>().isKinematic = false;
            PickUpObject.GetComponent<Rigidbody>().useGravity = true;
            PickUpObject.transform.position = Parent.transform.position;
            PickUpObject.transform.parent = null;
        }
        #endregion

        #region Grip Input

        #endregion

        //Teleport
        #region Touch Input
        if (Controls.GetPressDown(TouchButton)) {
            //Update ray position
            _Ray = new Ray(Parent.transform.position, Parent.transform.forward);

            //Ray cast to the ground
            if (Physics.Raycast(_Ray, out Hit)) {
                if (Hit.collider.tag.Equals("Ground")) {
                    NewLocation = Hit.point;
                    TeleportArea = Instantiate(TeleportMarker, Hit.point, Quaternion.Euler(90, 0, 0));
                    Ground = true;

                }
                else {
                    Destroy(TeleportArea, 1);

                    Ground = false;
                }
            }
        }

        //Teleport the player
        if (Controls.GetPressUp(TouchButton) && Ground) {
            Player.transform.position = new Vector3(NewLocation.x, NewLocation.y + 0.1f, NewLocation.z);
            Destroy(TeleportArea, 0.1f);
        }
        #endregion
    }

    void OnTriggerEnter(Collider _obj) {
        if (_obj.tag == "SentryCube" || _obj.tag == "PowerCube" || _obj.tag == "SmashCube" || _obj.tag == "AbsorbCube") {
            PickUpObject = _obj.gameObject;
        }
    }

    void OnTriggerExit(Collider _obj) {
        PickUpObject = null;
    }
}