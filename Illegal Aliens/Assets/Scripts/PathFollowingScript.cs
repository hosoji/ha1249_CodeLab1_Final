using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PathFollowingScript : MonoBehaviour {


	public Vector3[] path;

	float speed = 15f;
	float maxSpeed = 30f;

	int num = 1;

	Alien []alien;

	public int currentPos = 0;
	int previousPos;

	// Use this for initialization
	void Start () {
//		LineRenderer lr;
//		lr = gameObject.AddComponent<LineRenderer> ();
//		lr.material = new Material (Shader.Find("Sprites/Default"));
//		lr.widthMultiplier = 1f;
//		lr.numPositions = 9;
//
//		for (int i = 0; i < lr.numPositions; i++) {
//			lr.SetPosition (i, path1[i]);
//		}

		alien = GetComponentsInChildren<Alien> ();

		string pathFile = "path0" + GameManagerScript.instance.levelNum.ToString () + ".txt"; 

		PathData loadPath = new PathData(pathFile);

//		foreach (Vector3 pos in loadPath.posData) {
//			print (pos);
//		}

		path = loadPath.posData.ToArray ();

		transform.position = path [0];

		
	}
	
	// Update is called once per frame
	void Update () {



		float dist = Vector3.Distance (path [currentPos], transform.position);


		if (currentPos > 0) {
			previousPos = currentPos - 1;
		} else {	
			previousPos = 0;
		}


		if (Input.GetKey(KeyCode.A)){
			Move (maxSpeed, currentPos);
		}

		if (Input.GetKey (KeyCode.D)) {
			Move (maxSpeed, previousPos);
			Debug.Log (previousPos);

		}
			
		if (dist <= 0){
			currentPos++;
		}

		if (currentPos >= path.Length) {
			//currentPos = 0;
			Debug.Log ("YOU WIN!");
			GameManagerScript.instance.levelNum++;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

//		if (Input.GetKey(KeyCode.RightShift)){
//			for (int i = 0; i < alien.Length; i++) {
//				
//				alien[i].Ability (alien[i].transform.position);
//
//			}
//		}
//
//		if (!Input.GetKey (KeyCode.RightShift)) {
//			for (int i = 0; i < alien.Length; i++) {
//
//				alien[i].Reset (alien[i].transform.position);
//			}
//		}

		for (int i = 0; i < alien.Length; i++) {

			alien[i].Ability (alien[i].transform.position);

		}

//		Debug.Log ("Distance = " + dist);

	}
	void Move(float speed, int target ){
		transform.position = Vector3.MoveTowards(transform.position, path[target], Time.deltaTime * speed);


	}
		
}
