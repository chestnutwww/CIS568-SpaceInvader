using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public Transform shotSpawn2;
    public float fireRate;
    public float delay;
    private DestroyByContact instanceDie;

	// Use this for initialization
	void Start () {
        instanceDie = gameObject.GetComponent<DestroyByContact>();
        //InvokeRepeating("Fire", delay, fireRate);
        if (gameObject.tag == "BOSS")
            InvokeRepeating("Fire", 3.0f, 1.0f);
    }
	
    void FixedUpdate()
    {
        
        float value = Random.Range(0.0f, 1.0f);
        float JudgeVal = 0.0003f;       
        if (value < JudgeVal && instanceDie.die == false && gameObject.tag != "BOSS")
            Fire();
    }

	void Fire () {
        if (gameObject.tag != "BOSS")
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        else
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
        }
        GetComponent<AudioSource>().Play();
	}
}
