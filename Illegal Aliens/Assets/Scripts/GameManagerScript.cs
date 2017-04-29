using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	public static GameManagerScript instance;

	public int levelNum = 1;


	// Use this for initialization
	void Awake () {
		
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy (gameObject);
		}



	}
	
	// Update is called once per frame
	void Update () {

		print (levelNum);


		
	}
}
