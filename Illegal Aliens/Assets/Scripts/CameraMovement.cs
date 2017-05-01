using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Vector3[] cameraPath;

	public Vector3 targetPos;

	float timePressed;

	public bool nextLevel;

	public int currentPos = 0;

	ScreenShakeScript shake;


	void Start () {

		shake = GetComponent<ScreenShakeScript> ();

		string pathFile = "cameraPath.txt"; 

		PathData loadPath = new PathData(pathFile);

		cameraPath = loadPath.posData.ToArray ();

		transform.position = cameraPath [0];
	}
	

	void Update () {

		float dist = Vector3.Distance (cameraPath [currentPos], transform.position);
//		Debug.Log ("Camera current pos" + currentPos);


		if (dist <= 0){
			currentPos++;
		}

		if (nextLevel) {
			shake.enabled = false;
//
//			if (timePressed == 1f) {
//				timePressed = 0f;
//			}
	
			StartCoroutine ("MoveCamera", currentPos);
			nextLevel = false;
		} else {
			shake.enabled = true;
		}
	
	}

	IEnumerator MoveCamera(int target){

		timePressed = Mathf.Clamp01 (timePressed + Time.deltaTime);

		transform.position = Vector3.Lerp(transform.position,cameraPath[target], timePressed);
//		Debug.Log("Camera position: " + transform.position);

		yield return 0;
	}
		


}
