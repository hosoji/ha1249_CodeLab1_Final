using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour {

	public float forceAmount = 30;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		rb.AddForce (transform.up * forceAmount, ForceMode.Impulse);
		rb.AddForce (transform.up * forceAmount, ForceMode.Acceleration);
	}


		
}
