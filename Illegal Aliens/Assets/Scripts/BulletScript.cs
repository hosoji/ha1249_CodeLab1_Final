using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour {

	ImpactScript impact;

	public float forceAmount;
	Rigidbody rb;

	float bulletKillDelay = 10;

	ParticleSystem ps;


	// Use this for initialization
	void Start () {
		GameObject manager = GameObject.Find ("SceneManager");
		impact = manager.GetComponent<ImpactScript> ();
		rb = GetComponent<Rigidbody> ();

		ps = GetComponentInChildren<ParticleSystem> ();
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

		impact.EmitParticles (coll.transform.position, true);
		
//		ps.Emit(Random.Range(3,4));
//		Camera.main.GetComponent<ScreenShakeScript> ().Shaker(0.03f); 

		Destroy (coll.gameObject);
		Destroy (gameObject);




		}
		
}
