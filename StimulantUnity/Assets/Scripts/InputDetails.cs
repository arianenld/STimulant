using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputDetails : MonoBehaviour {

	public static float amount;
	public static string drugName;
	public static string absorptionType;
 	public static GameObject dropdownMenu;
    
	int menuIndex;
	string sValue;

	GameObject drugDropDown, typeDropDown, amountInputField, button;
	// Use this for initialization
	void Start () {
		drugDropDown = GameObject.Find("DrugDropDown");
		typeDropDown = GameObject.Find("TypeDropDown");
		amountInputField = GameObject.Find("AmountInputField");
		button = GameObject.FindWithTag("OnOff");

	}

	public void Listen(){
		var input = amountInputField.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SetAmount);
        input.onEndEdit = se;
	}

	private void SetAmount(string am)
    {
        if(am != "" && am != "0"){
			amount = float.Parse(am);
			button.SetActive(true);
        }

		else{
			amount = 0;
			button.SetActive(false);

		}

		Debug.Log("amount: " + amount);
    }

	public void SetDrug(){
		dropdownMenu = drugDropDown;
		drugName = GetValue();	
		print("Drug name: " + drugName);
	}

	public void SetAbsorption(){
		dropdownMenu = typeDropDown;

		absorptionType = GetValue();
		print("Type: " + absorptionType);
	}

	private string GetValue(){
		dropdownMenu.GetComponent<Dropdown>().RefreshShownValue();
		int menuIndex = dropdownMenu.GetComponent<Dropdown> ().value;

	    List<Dropdown.OptionData> menuOptions = dropdownMenu.GetComponent<Dropdown> ().options;

	    string sValue = menuOptions[menuIndex].text;
	   	Debug.Log(menuIndex);
	    return sValue;
	}
	
}
