using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	public static GameManagerScript instance;


	public int score = 100;


	// Use this for initialization
	void Awake () {
		


	}
	
	// Update is called once per frame
	void Update () {

		print (score);


		
	}
}
