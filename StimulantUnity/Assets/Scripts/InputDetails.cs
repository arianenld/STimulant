using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputDetails : MonoBehaviour {

	public static float amount;
	public static string drugName;
	public static string absorptionType;
 	public static GameObject dropdownMenu;

 	public static InputDetails Instance;
    
	int menuIndex;
	string sValue;

	GameObject drugDropDown, typeDropDown, amountInputField, button;

	bool dropDown1, dropDown2;

	Values val;
	// Use this for initialization
	/*public void Start () {
		drugDropDown = GameObject.Find("DrugDropDown");
		typeDropDown = GameObject.Find("TypeDropDown");
		amountInputField = GameObject.Find("AmountInputField");
		button = GameObject.FindWithTag("OnOff");

	}*/

	void Awake(){
		val = new Values();
		Instance = this;

	}

	/*public void SetGameObjects(){
		Values val = new Values();
		val.GetGameObjects();
		drugDropDown = val.drugDropDown;
		typeDropDown = val.typeDropDown;
		amountInputField = val.amountInputField;
		button = val.button;
	}*/

	public void Listen(){
		/*amountInputField = val.GetGameObjects("amount");
		var input = amountInputField.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SetAmount);
        input.onEndEdit = se;*/
	}

	public void SetAmount()
    {    
    	button = val.GetGameObjects("button");
    	amountInputField = val.GetGameObjects("amount");
    	string am = amountInputField.GetComponent<InputField>().text;

        if(am != "" && am != "0"){
			amount = float.Parse(am);
			button.GetComponent<Button>().interactable = true;
        }

		else{
			amount = 0;
			button.GetComponent<Button>().interactable = false;

		}

		Debug.Log("amount: " + amount);
    }

	public void SetDrug(){
		dropdownMenu = val.GetGameObjects("drug");
		drugName = GetValue();	
		print("Drug name: " + drugName);
	}

	public void SetAbsorption(){
		dropdownMenu = val.GetGameObjects("type");
		absorptionType = GetValue();
		print("Type: " + absorptionType);
	}

	private string GetValue(){
		Debug.Log(dropdownMenu);
		dropdownMenu.GetComponent<Dropdown>().RefreshShownValue();
		int menuIndex = dropdownMenu.GetComponent<Dropdown> ().value;

	    List<Dropdown.OptionData> menuOptions = dropdownMenu.GetComponent<Dropdown> ().options;

	    string sValue = menuOptions[menuIndex].text;
	   	Debug.Log(menuIndex);
	    return sValue;
	}
}
