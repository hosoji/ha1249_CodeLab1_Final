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

//		shake.enabled = true;
	}
	

	void Update () {

		float dist = Vector3.Distance (cameraPath [currentPos], transform.position);
//		Debug.Log ("distance is" + dist);
//		Debug.Log ("Camera Pos" + currentPos);
//
//		Debug.Log ("Shake is; " + shake.enabled);
//

//		print ("Next level is: " + nextLevel);
//		print ("Ready: " + ready);

		if (nextLevel) {


			StartCoroutine ("MoveCamera", currentPos);
			nextLevel = false;
		}

		if (Mathf.Approximately(timePressed , 1f)) {
				timePressed = 0f;
			}
//			nextLevel = false;
//		print (timePressed);

	
	}

	IEnumerator MoveCamera(int target){

		shake.enabled = false;

		timePressed = Mathf.Clamp01 (timePressed + Time.deltaTime);



		transform.position = Vector3.Lerp(transform.position,cameraPath[target], timePressed);


//		
//		shake.enabled = true;
		yield return 0;
	




	}
//
	public void UpdateCue (int i){
		CurrentPos = i;
//		if (l) {
//			if (ready) {
//
//				nextLevel = true;
//				ready = false;
//
//			}
//		} 
	}



}
