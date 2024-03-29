﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    void Awake() {
        GameObject[] Obj = GameObject.FindGameObjectsWithTag("GamePrefs");
        if (Obj.Length > 1) {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
