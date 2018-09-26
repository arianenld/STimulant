using System;
using UnityEngine;
using UnityEditor;
using System.IO;

public class TextFile{
	private string path = "Assets/Resources/Analytics.txt";


	public void WriteText(string toWrite){

		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine(toWrite);
		writer.Close();
	}

}