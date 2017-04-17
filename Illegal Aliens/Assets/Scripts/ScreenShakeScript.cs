using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeScript : MonoBehaviour {


	float shakeAmount = 0.5f;
	float shake = 0f;


	float  decreaseFactor = 1.0f;
	Vector3 camPos;


	// Use this for initialization
	void Start () {
		camPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (shake);

		if (shake > 0) {
			transform.position = Random.insideUnitSphere * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;

		} else {
			shake = 0.0f;
			transform.position = camPos;
		}
			
		
	}

	public void Shaker(float amount){
		if (shake <= 0.0f) {
			camPos = transform.position;
		}
		shake = amount;
		ChromaAdjuster effect = GetComponent<ChromaAdjuster> ();
		effect.SendMessage ("EffectOn");
		
	}
}
