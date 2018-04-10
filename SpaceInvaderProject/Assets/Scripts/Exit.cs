using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {

    void Start()
    {
        GameObject btnObj = GameObject.Find("ExitButton");
        Button btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            this.QuitGame();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void QuitGame()
    {
        Application.Quit();
    }
}
