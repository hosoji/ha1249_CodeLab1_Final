using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Vector3[] cameraPath;

	public Vector3 targetPos;

	float timePressed;

	public bool nextLevel;

	bool ready = true;



	private int currentPos;

	public int CurrentPos{
		get{
			return currentPos;
		}
		set{
			currentPos = value;

			if (currentPos >= cameraPath.Length) {
				currentPos = cameraPath.Length - 1;

			}
		}

	}


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
//		Debug.Log ("distance is" + dist);
		Debug.Log ("Camera Pos" + currentPos);


		//

//		if (dist <= 0) {
//			ready = true;
//		} else {
//			ready = false;
//		}


		print ("Next level is: " + nextLevel);
		print ("Ready: " + ready);

		if (nextLevel) {
			StartCoroutine ("MoveCamera", currentPos);




//			shake.enabled = false;
			AfterShift ();


//			if (timePressed == 1f) {
//				timePressed = 0f;
//			}
//			nextLevel = false;

//			StartCoroutine ("MoveCamera", currentPos);

		} else {
//			shake.enabled = true;
			ready = true;
		}
	
	}

	IEnumerator MoveCamera(int target){

		timePressed = Mathf.Clamp01 (timePressed + Time.deltaTime);


		transform.position = Vector3.Lerp(transform.position,cameraPath[target], timePressed);
//		Debug.Log("Camera position: " + transform.position);

		yield return 0;




	}

	public void UpdateCue (int i, bool l){
		CurrentPos = i;
		if (l) {
			if (ready) {

				nextLevel = true;
				ready = false;

			}
		} 
	}

	public void AfterShift(){
		nextLevel = false;
	}
		


}
