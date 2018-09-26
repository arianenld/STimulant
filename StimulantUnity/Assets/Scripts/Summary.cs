using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour {

	string drugName;
	string absorption;
	float amount;
    float time;

	GameObject timeField, amountField, drugNameField, absorptionField;

	public void Beng () {
		FindGameObjects();
		SetValues();
		Display();
		JsonSerialize();
	}

	void FindGameObjects(){
		timeField = GameObject.Find("Time");
		drugNameField = GameObject.Find("DrugName");
		absorptionField = GameObject.Find("Absorption");
		amountField = GameObject.Find("Amount");
	}

	void SetValues(){
		drugName = InputDetails.drugName;
		amount = InputDetails.amount;
		absorption = InputDetails.absorptionType;
		time = ComputeTime();
	}

	void Display(){
		timeField.GetComponent<Text>().text = time.ToString();
		absorptionField.GetComponent<Text>().text = absorption.ToString();
		amountField.GetComponent<Text>().text = amount.ToString();
		drugNameField.GetComponent<Text>().text = drugName.ToString();
	}

	void JsonSerialize(){
		Export exportObj = new Export();
		exportObj.drug_name = this.drugName;
		exportObj.amount_of_drugs = InputDetails.amount;
		exportObj.duration_in_body = this.time;
		exportObj.absorption_type = this.absorption;

		string json = JsonUtility.ToJson(exportObj);

		TextFile fileObj = new TextFile();
		fileObj.WriteText(json);
	}

	float ComputeTime(){

		return 0.0f;
	}
}
