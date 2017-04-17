using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	public static GameManagerScript instance;

//	Loader loader;

	//Use Constructors to load up pathpoints

	public Vector3[] path1 = { new Vector3 { x = 27, y = 36}, 
		new Vector3 { x = -58, y = 36},
		new Vector3 { x = -58, y = 24},
		new Vector3 { x = 27, y = 24},
		new Vector3 { x = 27, y = 12},
		new Vector3 { x = -58, y = 12},
		new Vector3 { x = -58, y = 0},
		new Vector3 { x = 27, y = 0},
		new Vector3 { x = 74, y = 0}};

	public Vector3[] path2 = { new Vector3 { x = -58, y = 0 }, 
		new Vector3 { x = 0, y = 0 },
		new Vector3 { x = 0, y = 34 },
		new Vector3 { x = -99, y = 34 }};


	// Use this for initialization
	void Awake () {
		
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy (gameObject);
		}

//		loader = new Loader ();
//		loader.temp = 0.123f;
//



	}
	
	// Update is called once per frame
	void Update () {



		
	}
}
