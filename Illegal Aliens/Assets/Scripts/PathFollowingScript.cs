using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PathFollowingScript : MonoBehaviour {


	public string[] fileNames;
	public Vector3[] path01;

	float speed = 15f;
	float maxSpeed = 30f;
	float target = 0;

	int num = 1;

	Alien []alien;

	public int currentPos = 0;

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

		PathData loadPath = new PathData("path01.txt");

//		foreach (Vector3 pos in loadPath.posData) {
//			print (pos);
//		}

		path01 = loadPath.posData.ToArray ();

		
	}
	
	// Update is called once per frame
	void Update () {

		float dist = Vector3.Distance (path01 [currentPos], transform.position);

		if (Input.GetKey(KeyCode.Space)){
			Move (speed);
		}

		if (Input.GetKey(KeyCode.LeftShift)){
			Move (maxSpeed);
		}
			
		if (dist <= target){
			currentPos++;
		}

		if (currentPos >= path01.Length) {
			//currentPos = 0;
			Debug.Log ("YOU WIN!");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

		if (Input.GetKey(KeyCode.RightShift)){
			for (int i = 0; i < alien.Length; i++) {
				
				alien[i].Ability (alien[i].transform.position);

			}
		}

		if (!Input.GetKey (KeyCode.RightShift)) {
			for (int i = 0; i < alien.Length; i++) {

				alien[i].Reset (alien[i].transform.position);
			}
		}

//		Debug.Log ("Distance = " + dist);
		
	}
	void Move(float speed ){
	transform.position = Vector3.MoveTowards(transform.position, path01[currentPos], Time.deltaTime * speed);
	}
		
}
