using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererScript : MonoBehaviour {
	
	public Vector3[] line;

	LineRenderer lr;

	PathFollowingScript playerPath;

	void Start () {



		string pathFile = "path01.txt"; 

		PathData loadPath = new PathData(pathFile);

		line = loadPath.posData.ToArray ();

		lr = gameObject.AddComponent<LineRenderer> ();
		lr.material = Resources.Load("Materials/Line", typeof(Material)) as Material;;
		lr.widthMultiplier = 1f;
		lr.positionCount = line.Length ;

		for (int i = 0; i < line.Length; i++) {
			Vector3 linePos = new Vector3 (line [i].x + 15, line [i].y - 11);
			lr.SetPosition (i, linePos);
		}


		GameObject myGameObject = GameObject.Find ("Formation Holder");

		playerPath = myGameObject.GetComponent<PathFollowingScript> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < line.Length; i++) {
			if (i <= playerPath.CurrentPos-1) {
				Vector3 pos = lr.GetPosition (playerPath.CurrentPos-1);
				lr.SetPosition (i, pos);
			}
		}
 
	}
}


