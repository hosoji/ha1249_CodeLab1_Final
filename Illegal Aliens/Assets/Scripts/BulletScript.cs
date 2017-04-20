using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour {



	public float forceAmount;
	Rigidbody rb;

	float bulletKillDelay = 10;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (transform.up * forceAmount, ForceMode.Impulse);
		rb.AddForce (transform.up * forceAmount, ForceMode.Acceleration);


		Vector3 screenPos = Camera.main.ScreenToViewportPoint (transform.position);

		if (screenPos.y > bulletKillDelay) { 	// top of viewport is 1)
			Destroy (gameObject);
		}

	}

	public void OnCollisionEnter (Collision coll){
		
		Destroy (gameObject);
		Destroy (coll.gameObject);
		Camera.main.GetComponent<ScreenShakeScript> ().Shaker(0.03f); 

		}
		
}
