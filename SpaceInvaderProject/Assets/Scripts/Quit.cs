using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject btnObj = GameObject.Find("QuitButton");  
        Button btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            this.QuitGame();
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void QuitGame() {
        Application.Quit();
    }
}
