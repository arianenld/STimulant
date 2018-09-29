using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

	public List<GameObject> panelList = new List<GameObject>();
	public static int currentPanel;

	void Awake () {
		Waypoints wp = new Waypoints();
		wp.SetWaypoints();
		currentPanel = 10;
		
 		foreach(var obj in GameObject.FindGameObjectsWithTag("Panel")){
			panelList.Add(obj);
			print(obj.transform.name);
			obj.SetActive(false);
		}

		EnablePanel();
	}

	public void EnablePanel(){
		Debug.Log(panelList.Count);
		Debug.Log("Clicked");

		string panelName = "Panel" + currentPanel;

		Debug.Log("Panel to enable: " + panelName);

		foreach(var panel in panelList){
			Debug.Log("Panels:: " + panel);
			if(panel.transform.name == panelName)
				panel.SetActive(true);

			else
				panel.SetActive(false);
		}

		if(currentPanel != 7)
			foreach(var drug in GameObject.FindGameObjectsWithTag("Drug"))
				Destroy(drug);

		if(currentPanel == 4){
			InputDetails.Instance.SetDrug();
			InputDetails.Instance.SetAbsorption();
		}
		
		/*if(currentPanel > panelList.Count)
			currentPanel = 1;*/
	}

	public void PreviousPanel(){
		currentPanel -= 1;
		this.EnablePanel();
	}

	public void NextPanel(){
		currentPanel += 1;
		this.EnablePanel();
	}

	public void GoToHome(){
		currentPanel = 1;
		this.EnablePanel();
	}
}
