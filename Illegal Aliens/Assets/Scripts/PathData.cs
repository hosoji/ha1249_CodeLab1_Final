using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class PathData {

	public List<Vector3> posData = new List<Vector3>();

	public Vector3 position;

	private const string POS_X = "xPos";
	private const string POS_Y = "yPos";
	private const string POS_Z = "zPos";

	public PathData(string fileName){


		JSONArray json = UtilScript.ReadJSONFromFile(Application.dataPath, fileName) as JSONArray;

//		Debug.Log (json);

		for (int i = 0; i < json.Count; i++) {

			position = new Vector3(json[i][POS_X].AsFloat, json[i][POS_Y].AsFloat, json[i][POS_Z].AsFloat);
			posData.Add (position);
//			Debug.Log(position);
		}
	}
		

	public PathData(Vector3 position){
		this.position = position;
	}
}
