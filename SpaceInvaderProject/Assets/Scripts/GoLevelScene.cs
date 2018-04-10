﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoLevelScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject btnObj = GameObject.Find("PlayButton");  
        Button btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            this.GoNextScene(btnObj);
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoNextScene(GameObject NScene)
    {
        SceneManager.LoadScene("Level");
    }
}
