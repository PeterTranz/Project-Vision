using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour {
    public AudioSource FinishSong;
    public AudioSource Bot;
    public string NextScene;
    public float PauseInterval;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider Finish) {
        if (Finish.gameObject.tag == "Player") {
            Bot.Stop();
            FinishSong.Play();
            Invoke("SceneChange", PauseInterval);
        }
    }

    void SceneChange() {
        SceneManager.LoadScene(NextScene);
    }
}
