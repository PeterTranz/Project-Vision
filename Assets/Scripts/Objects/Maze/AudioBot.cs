using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AudioBot : MonoBehaviour {
    public GameObject[] Checkpoints;
    public int i = 0;
    NavMeshAgent BotNav;

    public AudioSource[] BotAudio;
    AudioSource Music;
    AudioSource Blop;

	// Use this for initialization
	void Start () {
        BotNav = GetComponent<NavMeshAgent>();
        BotNav.SetDestination(Checkpoints[i].transform.position);

        BotAudio = GetComponents<AudioSource>();
        Music = BotAudio[0];
        Blop = BotAudio[1];
    }
	
	// Update is called once per frame
	void Update () {

        if (i >= Checkpoints.Length) {
            i = Checkpoints.Length;
        }
        BotNav.SetDestination(Checkpoints[i].transform.position);
    }

    //Player Detection
    void OnCollisionEnter(Collision Bot) {
        if (Bot.gameObject.tag == "Player") {
            i += 1;
            Music.Pause();
            Blop.Play();
            //Music.UnPause();
            Invoke("UnpauseMusic", 0.75f);
        }
    }

    void UnpauseMusic() {
        Music.UnPause();
    }
}
