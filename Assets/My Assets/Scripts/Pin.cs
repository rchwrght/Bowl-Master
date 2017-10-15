using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 5f;
    public float distToRaise = 40f;

    private Rigidbody rb;

	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	}

    public bool IsStanding() {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if (tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Raise()
    {
        rb = GetComponent<Rigidbody>();
        transform.Translate(new Vector3(0f, distToRaise, 0f), Space.World);
        rb.useGravity = false;
        transform.rotation = Quaternion.Euler(270f, 0, 0);
    }

    public void Lower()
    {
        rb = GetComponent<Rigidbody>();
        transform.Translate(new Vector3(0f, -distToRaise, 0f), Space.World);
        rb.useGravity = true;
    }
}
