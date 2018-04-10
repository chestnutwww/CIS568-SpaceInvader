using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunkerController : MonoBehaviour {

    public int maxHP;
    private int curHP;

    public Text DisplayHP;

    void Start()
    {
        DisplayHP.text = "10/10";
        curHP = maxHP;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Player" || other.tag == "deadbody" || other.tag == "resBolt")
        {
            return;
        }
        Destroy(other.gameObject);
        --curHP;
        DisplayHP.text = curHP + "/10";
        if (curHP <= 0)
        {
            Destroy(gameObject);
            DisplayHP.text = "";
        }
            
    }

    // Update is called once per frame
    void Update () {
        //Destroy(gameObject);
    }
}
