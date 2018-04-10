using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    void Start()
    {
        GameObject btnObj = GameObject.Find("NewButton");
        Button btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            this.GoNextScene(btnObj);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoNextScene(GameObject NScene)
    {
        SceneManager.LoadScene("Level");
    }
}
