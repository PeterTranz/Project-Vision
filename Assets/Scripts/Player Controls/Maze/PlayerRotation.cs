using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
    public AudioSource Blop;
    public AudioSource Bot;

    public GameObject PlayerHead;
    public GameObject PlayerRig;
    GameObject obj;

	// Use this for initialization
	void Start () {
        obj = this.gameObject;
	}

    // Update is called once per frame
    void Update() {
        //this.transform.localRotation = PlayerHead.transform.localRotation;
        this.transform.localEulerAngles = new Vector3(0, PlayerHead.transform.localEulerAngles.y, 0);
        
        PlayerRig.transform.localPosition = this.transform.localPosition;
    }

    //When the player hits the audio bot
    void OnCollisionEnter(Collision PlayerRelative) {
        if (PlayerRelative.gameObject.tag == "AudioBot") {
            Bot.Pause();
            Blop.Play();
            Invoke("UnpauseMusic", 0.5f);
        }
    }

    void UnpauseMusic() {
        Bot.UnPause();
    }
}
