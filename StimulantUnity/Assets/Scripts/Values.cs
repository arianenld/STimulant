using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Values	{

	public GameObject drugDropDown;
	public GameObject typeDropDown;
	public GameObject amountInputField;
	public GameObject button;


	public GameObject GetGameObjects(string val){

		if(val == "drug")
			return GameObject.Find("DrugDropDown");

		else if(val == "type")
			return GameObject.Find("TypeDropDown");

		else if(val == "amount")
			return GameObject.Find("AmountInputField");

		else
			return GameObject.FindWithTag("OnOff");
	}

}