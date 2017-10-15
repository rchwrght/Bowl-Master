using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;

    private GameManager gameManager;
    private bool ballLeftBox = false;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    private int lastSettledCount = 10;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ballLeftBox)
        {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
        standingDisplay.text = CountStanding().ToString();
    }

    public void Reset() {
        lastSettledCount = 10;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Bowling Ball")
        {
            ballLeftBox = true;
         }
    }

    void UpdateStandingCountAndSettle()
    {
        //Update the last standing count
        //Call pins have settled method
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; //Pin Settle wait time
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {

        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall);

        lastStandingCount = -1;
        ballLeftBox = false;
        standingDisplay.color = Color.green;
    }

    int CountStanding()
    {
        int standingPin = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding()) { standingPin++; }
        }
        return standingPin;
    }
}
