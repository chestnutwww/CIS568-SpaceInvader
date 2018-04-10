using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Restart", 5.0f);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void Restart() {
        SceneManager.LoadScene("Intro");
    }
    
}
