using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ForButtons : MonoBehaviour {

	PanelController panelControl  = new PanelController();


	/*void Awake(){
		panelControl
	}*/

	public void PreviousPanel(){
		panelControl.currentPanel -= 1;
		panelControl.EnablePanel();
	}

	public void NextPanel(){
		panelControl.currentPanel += 1;
		panelControl.EnablePanel();
	}

	
}
