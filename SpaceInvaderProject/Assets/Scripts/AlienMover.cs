using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMover : MonoBehaviour {

    public float initialspeed;

    // Use this for initialization
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * initialspeed;

    }

    // Update is called once per frame
    void Update()
    {

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb.position.z < -2.4f)
        {
            Destroy(gameObject);
        }

        if (rb.position.x > 7.5f || rb.position.x < -7.5f)
        {
            Vector3 temp = rb.velocity;
            temp.x *= -1.0f;
            temp.x += Mathf.Sign(temp.x) * 0.2f;
            rb.velocity = temp;

            rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z - 0.3f);
        }
    }
}
