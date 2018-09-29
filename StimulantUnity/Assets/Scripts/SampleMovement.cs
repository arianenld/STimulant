using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMovement : MonoBehaviour {

	public List<Vector3> waypoints;
	public int currentWaypoint;
	public float speed = 1f;
	public float lerpTime = 2f;
	float currentLerpTime;
	Vector3 startPos;
    Vector3 targetPoint;
    Vector3 steps;
    float moveDistance = 10f;

	void Start () {
		this.waypoints = Waypoints.GetWaypoints("Urinary");

		currentWaypoint = 0;
		startPos = transform.localPosition;

		targetPoint = waypoints[currentWaypoint];
	}
	
	// Update is called once per frame
	void Update () {
		if(currentWaypoint < this.waypoints.Count){
			if(targetPoint == null){
			 	currentLerpTime = 0;
			 	targetPoint = waypoints[0];
			}

			Move();
		}
	}

	void Move(){
 
        //increment timer once per frame
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }

		if(transform.localPosition == targetPoint){
			if(currentWaypoint == this.waypoints.Count - 1){
				currentWaypoint = -1;
				startPos = this.waypoints[0];
			}

			else
				startPos = transform.localPosition;

			currentLerpTime = 0;
			currentWaypoint++;
			targetPoint = this.waypoints[currentWaypoint];
		}

		float perc = currentLerpTime / lerpTime;
        transform.localPosition = Vector3.Lerp(startPos, targetPoint, perc);
	}
}
