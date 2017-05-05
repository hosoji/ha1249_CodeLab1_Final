using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableBullet : Poolable { 



	Rigidbody rb;

	TrailRenderer tr;

	Renderer rend;

	float bulletKillDelay = 2;


	GameObject attacker;

	public override void Setup ()
	{
		attacker = GameObject.Find("Attacker Holder"); 
		GameObject manager = GameObject.Find ("SceneManager");


		rend = GetComponent<Renderer>();

	}

	public override bool RePool(){ 
//		Vector3 screenPos = Camera.main.ScreenToViewportPoint (transform.position);
//
//		return screenPos.y > bulletKillDelay; 
		return (!rend.isVisible);
	}

	public override void Reset(){ 


		if(attacker == null){
			attacker = GameObject.Find("Attacker Holder"); 
		}

		rb = GetComponent<Rigidbody> ();
		tr = GetComponent<TrailRenderer> ();

		float offSetX = 1;
		float offSetY = 2;
		transform.position = new Vector3 (transform.position.x + offSetX, attacker.transform.position.y + offSetY, attacker.transform.position.z);
		transform.rotation = attacker.transform.rotation;

		rb.velocity = Vector3.zero; 
		tr.Clear();

	}

	public void OnCollisionEnter (Collision coll){


		GameObject impact = ObjectPooling.GetFromPool("Impact");

		impact.GetComponent<PoolableImpact> ().EmitParticles (coll.transform.position);

		GameObject manager = GameObject.Find ("SceneManager");
		manager.GetComponent<ScoreManager> ().score--;



		Destroy (coll.gameObject);


		ObjectPooling.AddToPool (gameObject);





	}
}
