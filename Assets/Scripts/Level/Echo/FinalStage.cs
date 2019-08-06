using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalStage : MonoBehaviour {
    public GameObject Button;
    public AudioSource FinalMusic;
    public string NextScene;
    public float PauseInterval;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool Complete = Button.GetComponent<Button>().Active;

        if (Complete) {
            //Game is finished
            FinalMusic.Play();
            Invoke("SceneChange", PauseInterval);
        }
	}

    void SceneChange() {
        SceneManager.LoadScene(NextScene);
    }
}
