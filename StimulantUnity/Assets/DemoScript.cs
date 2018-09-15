using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour {

	public Light myLight;

	void Update(){
		if(Input.GetKey("space")){
			myLight.enabled = true;
		}

		else{
			myLight.enabled = false;
		}
	}
}
