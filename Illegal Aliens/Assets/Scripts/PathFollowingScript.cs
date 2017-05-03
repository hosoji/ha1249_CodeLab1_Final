using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PathFollowingScript : MonoBehaviour {


	public Vector3[] path;


	float speed = 15f;
	float maxSpeed = 30f;

	public int[] cameraCues = {8, 20, 29 };

	int num = 0;


	Alien []alien;

	private int currentPos;

	public int CurrentPos{
		get{
			return currentPos;
		}
		set{
			currentPos = value;

			if (currentPos >= path.Length) {
				currentPos = path.Length - 1;

			}
		}

	}

	int previousPos;

	// Use this for initialization
	void Start () {



		alien = GetComponentsInChildren<Alien> ();

		string pathFile = "path01.txt"; 

		PathData loadPath = new PathData(pathFile);


		path = loadPath.posData.ToArray ();

		transform.position = path [0];


	}
	
	// Update is called once per frame
	void Update () {
		CameraMovement shift = Camera.main.GetComponent<CameraMovement> ();

		for (int i = 0; i < cameraCues.Length; i++) {

			if (currentPos == cameraCues [i]) {

				print (i + 1);
				shift.UpdateCue (i + 1);
				shift.nextLevel = true;


			} else {
//				shift.nextLevel = false;
			}
		}



		float dist = Vector3.Distance (path [currentPos], transform.position);


		if (currentPos > 0) {
			previousPos = currentPos - 1;
		} else {	
			previousPos = 0;
		}


		if (Input.GetKey(KeyCode.Space)){
			Move (maxSpeed, currentPos);
		}

		if (Input.GetKey (KeyCode.Z)) {
			Move (maxSpeed, previousPos);
//			Debug.Log (previousPos);

		}
			
		if (dist <= 0){
			CurrentPos++;
			print ("Current player pos: " +currentPos);
	
		}

		if (currentPos >= path.Length -1 ) {
			//currentPos = 0;
			Debug.Log ("YOU WIN!");

			SceneManager.LoadScene (0);


		}



		for (int i = 0; i < alien.Length; i++) {

			alien[i].SetPlane (alien[i].transform.position);

		}

//		Debug.Log ("Distance = " + dist);

	}
	void Move(float speed, int target ){
		transform.position = Vector3.MoveTowards(transform.position, path[target], Time.deltaTime * speed);


	}
		
}
