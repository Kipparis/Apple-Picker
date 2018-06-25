using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame() {
        Application.LoadLevel("_Scene_0");
    }

    public void DeleteScore() {
        print("DeleteScore clicked");
        GameObject hg = GameObject.Find("HighScore");
        hg.GetComponent<HighScore>().ClearScore();
    }
}
