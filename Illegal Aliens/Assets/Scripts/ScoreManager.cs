using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public int score = 100;

	TextMesh scoreText;
	// Use this for initialization
	void Start () {
		GameObject score = GameObject.Find ("Score");
		scoreText = score.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
//		print (score);
		scoreText.text = score.ToString();
	}
}
