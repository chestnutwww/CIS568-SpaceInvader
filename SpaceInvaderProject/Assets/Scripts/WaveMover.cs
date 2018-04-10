using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveMover : MonoBehaviour {

    public float initialspeed;
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

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * initialspeed;

        foreach (Transform child in transform)
        {
            Rigidbody rbChild = child.GetComponent<Rigidbody>();
            rbChild.velocity = rb.velocity;
        }
    }

    void FixedUpdate () {

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb.position.z < -0.8f)
        {
            Destroy(gameObject);
            //SceneManager.LoadScene("GameOver");
            Destroy(GameObject.FindWithTag("Player"));
            gameController.LoseLive();
        }

        Vector3 temp = rb.velocity;
        float delta_z = 0;
        if (rb.position.x > 3.5f || rb.position.x < -3.5f)
        {
            temp.x *= -1.0f;
            temp.x += Mathf.Sign(temp.x) * 0.2f;
            rb.velocity = temp;
            delta_z = -0.2f;
            rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z - 0.2f);
        }
        if (delta_z < 0) { 
            foreach (Transform child in transform)
            {
                Rigidbody rbChild = child.GetComponent<Rigidbody>();
                rbChild.velocity = temp;
                rbChild.position = new Vector3(rbChild.position.x, rbChild.position.y, rbChild.position.z +delta_z);
            }
        }
    }

    void LateUpdate()
    {
        if (transform.childCount <= 0)
        {
            Destroy(gameObject);
            gameController.AddLive();
            gameController.AddScore(gameController.clearAllScore);

            if (gameController.GetLevel() >= gameController.bossLevel - 1)
            {
                gameController.AddLevel();
                gameController.GenerateBoss();
            }
            else
            {
                gameController.GenerateWave();
                gameController.AddLevel();
            }
                
        }
            
    }
}
