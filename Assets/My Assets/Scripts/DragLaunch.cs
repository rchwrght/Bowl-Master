using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof (Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 startPosition, endPosition;
    private float startTime;

	void Start () {
        ball = GetComponent<Ball>();
	}

    public void DragStart() {
        startPosition = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd() {
        float duration = Time.time - startTime;
        endPosition = Input.mousePosition;

        float launchSpeedX = (endPosition.x - startPosition.x) / duration;
        float launchSpeedZ = (endPosition.y - startPosition.y) / duration;

        /* my messy way of doing it
        Vector3 launchVelocity = (new Vector3(endPosition.x, 0f, endPosition.y)  - new Vector3(startPosition.x, 0f, startPosition.y)) / duration;
        */

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0f, launchSpeedZ);
        if (!ball.inPlay)
        {
            ball.Launch(launchVelocity);
        }
    }

    public void MoveStart(float xNudge) {
        if (!ball.inPlay)
        {
            ball.transform.Translate(new Vector3(xNudge, 0, 0));
            float xBallPos = ball.transform.position.x;
            float yBallPos = ball.transform.position.y;
            float zBallPos = ball.transform.position.z;
            ball.transform.position = new Vector3(Mathf.Clamp(xBallPos, -52.5f, 52.5f), yBallPos, zBallPos);
        }
    }

}
