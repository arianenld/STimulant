using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeController : MonoBehaviour {

	public Vector3 defaultPlace;
	public float timer;
    public float speed;
    public float delay;

	void Start () {
		defaultPlace = transform.position;
		timer = 0f;
        speed = 5f;
        delay = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		if(PanelController.currentPanel == 6){
			MoveSyringe();
		}
	}

	void MoveSyringe(){
		timer += Time.deltaTime;

		if(timer < delay){
			float step = speed * Time.deltaTime;
	        transform.Translate(0f, 0f, -step);
    	}

    	else{
    		timer = 0f;
    		transform.position = defaultPlace;
    	}
	}
}
