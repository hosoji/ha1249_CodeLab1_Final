using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AttackerLoader : MonoBehaviour {
	public string[] fileNames;

	float offsetX = 0;
	float offsetY = 0;

	// Use this for initialization
	void Start () {
		string fileName = fileNames[0];

		string filePath = Application.dataPath +"/"+ fileName;


		StreamReader sr = new StreamReader (filePath);

		GameObject attackerHolder = new GameObject ("Attacker Holder");

		int yPos = 0;


		while (!sr.EndOfStream) {
			string line = sr.ReadLine ();

			for (int xPos = 0; xPos < line.Length; xPos++) {

				if (line [xPos] == 'O') {
					GameObject unit = GameObject.CreatePrimitive (PrimitiveType.Cube);

					unit.transform.parent = attackerHolder.transform;

					unit.transform.position = new Vector3 (xPos + offsetX, yPos + offsetY, 0);
				}
			}
			yPos--;
		}

		sr.Close ();


		attackerHolder.transform.position = new Vector3 (0, -27, 0);

		attackerHolder.AddComponent<AttackerScript> ();


	}

}
