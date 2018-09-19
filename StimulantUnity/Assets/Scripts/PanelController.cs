using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

	public List<GameObject> panelList = new List<GameObject>();
	public int currentPanel = 1;

	void Awake () {
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
	}

	public void PreviousPanel(){
		this.currentPanel -= 1;
		this.EnablePanel();
	}

	public void NextPanel(){
		this.currentPanel += 1;
		this.EnablePanel();
	}

	public void GoToHome(){
		this.currentPanel = 1;
		this.EnablePanel();
	}
}
