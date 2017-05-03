using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AttackerLoader : MonoBehaviour {
	public string[] fileNames;

	float offsetX = 0;
	float offsetY = 0;

	int enemyNum = 7;

	public enum AttackerType {
		FRONT, BACK, MID
	}

	public AttackerType type;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < enemyNum; i++) {
			
			GameObject attacker = LoadAttacker ();

			attacker.layer = 8;



			switch (type) {
			case AttackerType.MID:
				Debug.Log ("Attacker type is: " + type);
				attacker.transform.position = new Vector3 (0, -27, 0);
				break;
			case AttackerType.FRONT:
				attacker.transform.position = new Vector3 (0, -27, -10);
				Debug.Log ("Attacker type is: " + type);
				break;
			case AttackerType.BACK:
				attacker.transform.position = new Vector3 (0, -27, 10);
				Debug.Log ("Attacker type is: " + type);
				break;


			}
		}

	}

	GameObject LoadAttacker(){

		string fileName = fileNames[Random.Range(0,3)];

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




		if (fileName == fileNames[0]){
			attackerHolder.AddComponent<MidPlaneAttacker> ();
			type = AttackerType.MID;


		}

		if (fileName == fileNames[1]){
			attackerHolder.AddComponent<FrontPlaneAttacker> ();
			type = AttackerType.FRONT;


		}

		if (fileName == fileNames[2]){
			attackerHolder.AddComponent<BackPlaneAttacker> ();
			type = AttackerType.BACK;



		}

		return attackerHolder;

	}

}
