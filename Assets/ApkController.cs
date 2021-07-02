using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApkController : MonoBehaviour {

    public MenuController menuCtrl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) {
            menuCtrl.ToggleGamePause();
        }
    }
}
