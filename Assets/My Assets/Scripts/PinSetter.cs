using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {



    public GameObject PinSetUp;

    private float distanceToRaise = 40f;

    private Animator animator;
    private PinCounter pinCounter;

    private ActionMaster actionMaster = new ActionMaster();

    // Use this for initialization
    void Start () {
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        animator = GetComponent<Animator>();
    }
	
	void Update () {

	}


    void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<Pin>()) {
            Destroy(obj);
        }
        
    }

    public void RaisePins() {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) {
                pin.Raise();
            }
        }
    }

    public void LowerPins() {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Lower();
        }
    }

    public void Renew()
    {
        GameObject Pin = Instantiate(PinSetUp) as GameObject;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            Rigidbody rb = pin.GetComponent<Rigidbody>();
            pin.transform.Translate(new Vector3(0f, distanceToRaise, 0f), Space.World);
            rb.useGravity = false;
        }
    }

    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle End Game!");
        }
    }
}
