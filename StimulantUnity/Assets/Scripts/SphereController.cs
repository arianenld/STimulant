using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {


	//public Transform target;
	Vector3 startPos;

	float timer = 0f;
	float speed = 1f;
	float delay;

	void Start () {
		print("Sphere yeah");
	 	delay = 5f;
	 	 startPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if(timer < delay){
			float step = speed * Time.deltaTime;
          	//transform.position = Vector3.MoveTowards(transform.position, target.position, step);
          	transform.Translate(step, 0f, 0f);
		}

		else{
			timer = 0f;
			this.transform.position = startPos;
		}

		if(Input.GetKey("a"))
			transform.Translate(-.5f*Time.deltaTime, 0f, 0f);

		else if(Input.GetKey("d"))
			transform.Translate(.5f*Time.deltaTime, 0f, 0f);
	}
}
