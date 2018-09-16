using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

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
