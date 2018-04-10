using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public int scoreValue;
    private GameplayController gameController;
    public GameObject deadAlien;
    public GameObject deadBolt;
    public bool die;

    

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("gameplayController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameplayController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        if (gameObject.transform.parent != null || gameObject.tag == "ship" || gameObject.tag == "BOSS")
            die = false;
        else
        {
            die = true;
            deadAlien.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.tag == "Boundary" || gameObject.tag == "deadbody" && other.tag == "Bolt")
        {
            return;
        }
        if (other.tag == "Bolt")
        {
            // Generate dead bolt
            generateDeadBolt(other);
            Destroy(other.gameObject);

            if (gameObject.tag != "BOSS")
            {
                gameController.AddScore(scoreValue);

                // Generate dead body
                generateDeadBody();
                Destroy(gameObject);

                //deadAlien.GetComponent<Collider>().isTrigger = false;
                deadAlien.GetComponent<Rigidbody>().useGravity = true;
                //die = true;
            }
            else
            {
                gameController.BossLoseHP();
                //Destroy(gameObject);
            }

        }
        

    }

    void generateDeadBody()
    {
        GameObject a = Instantiate(deadAlien, gameObject.transform.position, gameObject.transform.rotation);
        a.GetComponent<DestroyByContact>().die = true;
        //a.GetComponent<Collider>().isTrigger = true;
        a.tag = "deadbody";        
    }

    void generateDeadBolt(Collider other)
    {
        GameObject b = Instantiate(deadBolt, other.gameObject.transform.position, other.gameObject.transform.rotation);
    }

}
