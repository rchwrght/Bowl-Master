using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;
    public bool inPlay = false;

    private Rigidbody rb;
    private AudioSource audioSource;
    private Vector3 ballStartPos;

	void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rb.useGravity = false;
        ballStartPos = transform.position;
	}
	
	void Update () {

    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        rb.useGravity = true;
        rb.velocity = velocity;
        audioSource.Play();
    }

    public void Reset()
    {
        inPlay = false;
        transform.position = ballStartPos;
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
    }
}
