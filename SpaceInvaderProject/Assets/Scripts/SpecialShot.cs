using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialShot : MonoBehaviour {

    public GameObject shot;
    public float speed;
    public Quaternion rotation;

    private GameplayController gameController;

    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("gameplayController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameplayController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R) && gameController.GetNumResBolt() > 0)
        {
            foreach (Transform child in transform)
            {
                Transform subTrans = child.GetComponent<Transform>();
                //rotation = subTrans.rotation;
                rotation.eulerAngles = new Vector3(0, -90, 0);
                GameObject a = Instantiate(shot, subTrans.position, rotation);
                //a.tag = "specialBolt";
                GetComponent<AudioSource>().Play();
            }
            gameController.LoseResBolt();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (Transform child in transform)
            {
                Transform subTrans = child.GetComponent<Transform>();
                //rotation = subTrans.rotation;
                rotation.eulerAngles = new Vector3(0, -90, 0);
                GameObject a = Instantiate(shot, subTrans.position, rotation);
                //a.tag = "specialBolt";
                GetComponent<AudioSource>().Play();
            }
            //gameController.LoseResBolt();
        }
    }
}
