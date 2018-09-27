using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CsvFile{
	private string path = "Assets/Resources/Analytics.csv";
	private List<string[]> rowData = new List<string[]>();


	public void WriteCsv(string[] toWrite){
		string[] rowDataTemp = new string[4];
        rowDataTemp[0] = toWrite[0];
        rowDataTemp[1] = toWrite[1];
        rowDataTemp[2] = toWrite[2];
        rowDataTemp[3] = toWrite[3];
        rowData.Add(rowDataTemp);

        string[][] output = new string[rowData.Count][];

        for(int i = 0; i < output.Length; i++){
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();
        
        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));
        
        StreamWriter writer = System.IO.File.AppendText(path);
        writer.Write(sb);
        writer.Close();
	}
}