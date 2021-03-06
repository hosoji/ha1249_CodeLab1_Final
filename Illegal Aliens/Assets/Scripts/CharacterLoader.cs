﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class CharacterLoader : MonoBehaviour {

	public string[] fileNames;

	GameObject formationHolder;
//	public static int levelNum;

	float offsetX = 0;
	float offsetY = 0;
//
//	public float startX;
//	public float startY;

	// initializatize level
	void Start () {




//		levelNum = Random.Range (0, fileNames.Length);

		string mainFile = fileNames [3];


		string firstPath = Application.dataPath +"/"+ mainFile;

		StreamReader sr1 = new StreamReader (firstPath);

		formationHolder = new GameObject ("Formation Holder");

		int formationYPos = 0;


		while (!sr1.EndOfStream) {
			string formationLine = sr1.ReadLine ();

			for (int formationXPos = 0; formationXPos < formationLine.Length; formationXPos++) {
				
				string fileName = fileNames[Random.Range(0,3)];

				string filePath = Application.dataPath +"/"+ fileName;

				if (formationLine [formationXPos] == 'X') {
			
					StreamReader sr2 = new StreamReader (filePath);

					GameObject playerHolder = new GameObject ("Player Holder: " + formationXPos.ToString ());

					int yPos = 0;


					while (!sr2.EndOfStream) {
						string line = sr2.ReadLine ();

						for (int xPos = 0; xPos < line.Length; xPos++) {

							if (line [xPos] == 'O') {
								GameObject unit = GameObject.CreatePrimitive (PrimitiveType.Cube);

								unit.transform.parent = playerHolder.transform;

								unit.transform.position = new Vector3 (xPos + offsetX, yPos + offsetY, Mathf.PerlinNoise(-2,2));
							}
						}
						yPos--;
					}
					sr2.Close ();

					playerHolder.transform.parent = formationHolder.transform;

					playerHolder.transform.position = new Vector3 (formationXPos, formationYPos);

					if (fileName == fileNames[0]){
						playerHolder.AddComponent<MidPlaneAlien> ();
					}

					if (fileName == fileNames[1]){
						playerHolder.AddComponent<IntrovertAlien> ();
					}

					if (fileName == fileNames[2]){
						playerHolder.AddComponent<ExtrovertAlien> ();
					}


				}
			}
			formationYPos--;
		}
			
		sr1.Close ();

//		formationHolder.transform.position = new Vector3 (startX, startY, 0);

		formationHolder.AddComponent<PathFollowingScript> ();

//		formationHolder.transform.parent = GameObject.Find ("GameManager").transform;
	}
		
}
