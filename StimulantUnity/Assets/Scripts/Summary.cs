using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;

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
		ToJson();
		ToCsv();
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

	void ToJson(){
		Export exportObj = new Export();
		exportObj.drug_name = this.drugName;
		exportObj.amount_of_drugs = InputDetails.amount;
		exportObj.duration_in_body = this.time;
		exportObj.absorption_type = this.absorption;

		string json = JsonUtility.ToJson(exportObj);

		TextFile fileObj = new TextFile();
		fileObj.WriteText(json);
	}

	void ToCsv(){
		CsvFile csv = new CsvFile();
		//var data = new List<dynamic>();
		string[] data = new string[4];
		data[0] = this.drugName;
		data[1] = this.absorption;
		data[2] = InputDetails.amount.ToString();
		data[3] = this.time.ToString();

		csv.WriteCsv(data);

	}

	float ComputeTime(){

		return 0.0f;
	}
}
