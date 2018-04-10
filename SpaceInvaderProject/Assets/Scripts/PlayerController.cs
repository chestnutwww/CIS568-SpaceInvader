using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public GameObject explosion;
    //public float fireRate;

    private GameplayController gameController;

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
    }

    
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Bolt_Enemy")
        {
            gameController.LoseLive();
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.tag == "resBolt")
        {
            Destroy(other.gameObject);
            gameController.AddResBolt();
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            -3.5f
        );
    }

    /*
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            -3.5f
        );

    }
    */
}
