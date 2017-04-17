using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour {



	public float forceAmount;
	Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (transform.up * forceAmount, ForceMode.Impulse);
		rb.AddForce (transform.up * forceAmount, ForceMode.Acceleration);

	}

	public void OnCollisionEnter (Collision coll){
		
		Destroy (gameObject);
		Destroy (coll.gameObject);
		Camera.main.GetComponent<ScreenShakeScript> ().Shaker(0.03f); 

		}
		
}
