using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    
    // Use this for initialization
	void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        //if(gameObject.tag == "specialBolt")
            //rb.velocity = transform.right * speed;
        //else
            rb.velocity = transform.forward * speed;
    }
	
}
