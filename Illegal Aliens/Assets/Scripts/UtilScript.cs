using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class UtilScript : MonoBehaviour {



	public static void WriteJSONtoFile(string path, string fileName, JSONClass json){
		WriteStringToFile (path, fileName, json.ToString ());
	}

	public static void WriteStringToFile ( string path, string fileName, string content){
		StreamWriter sw = new StreamWriter (path + "/" + fileName);

		sw.Write (content);

		sw.Close ();
	}

	public static JSONNode ReadJSONFromFile(string path, string fileName){
		return JSON.Parse(ReadStringFromFile (path, fileName));
	}

	public static string ReadStringFromFile(string path, string fileName){
		StreamReader sr = new StreamReader (path + "/" + fileName);

		string result = sr.ReadToEnd ();

		sr.Close ();

		return result;
	}
		


	public static void SaveTransformPosition(Transform t, string path, string name) {

		const char DELIMITER = '|';

		Vector3 transformPos = t.position;
		string content = "" + transformPos.x + DELIMITER + transformPos.y + DELIMITER + transformPos.z; 

		WriteStringToFile (path, name, content);
	}

//
//	public static Vector3[] GetPaths(string path, string fileName){
//
//		const char DELIMITER = '|';
//
//		string filePath = path + fileName;
//
//		StreamReader sr = new StreamReader (filePath);
//
//		int yPos = 0;
//
//
//		while (!sr.EndOfStream) {
//			string line = sr.ReadLine ();
//
//
//			string[] splitLine = line.Split (DELIMITER);
//
//			transform.position = new Vector3 (float.Parse (splitLine [0]), float.Parse (splitLine [1]));
//			yPos--;
//		}
//
//		sr.Close ();
//	}
//		



	float remapRange(float oldValue, float oldMin, float oldMax, float newMin, float newMax )
	{
		float newValue = 0;
		float oldRange = (oldMax - oldMin);
		float newRange = (newMax - newMin);
		newValue = (((oldValue - oldMin) * newRange) / oldRange) + newMin;
		return newValue;
	}
		

}
