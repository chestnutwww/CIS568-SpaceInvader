using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMover : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;
    }
}
