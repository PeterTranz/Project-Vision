using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCommands : MonoBehaviour {
    Scene CurrentLevel;

    // Use this for initialization
    void Start () {
        CurrentLevel = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
        //Game manager inputs "R"
        if (Input.GetKey(KeyCode.R)) {
            //Restart the level
            SceneManager.LoadScene(CurrentLevel.name);
        }

        //Game manager inputs "R"
        if (Input.GetKey(KeyCode.Q)) {
            //Quit Game
            Application.Quit();
        }
    }
}
