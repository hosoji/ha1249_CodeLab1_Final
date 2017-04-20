using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLights : MonoBehaviour {


	GameObject target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Attacker Holder");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = target.transform.position;
		transform.Rotate (1, 1, 0);
		transform.position = new Vector3 (target.transform.position.x, transform.position.y, transform.position.z);
	}
}
