using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableBullet : Poolable { 

	ImpactScript impact;

	Rigidbody rb;

	TrailRenderer tr;

	float bulletKillDelay = 10;

	ParticleSystem ps;

	GameObject attacker;

	public override void Setup ()
	{
		attacker = GameObject.Find("Attacker Holder"); 
		GameObject manager = GameObject.Find ("SceneManager");
		impact = manager.GetComponent<ImpactScript> ();


		ps = GetComponentInChildren<ParticleSystem> ();
	}

	public override bool RePool(){ 
		Vector3 screenPos = Camera.main.ScreenToViewportPoint (transform.position);

		return screenPos.y > bulletKillDelay; 
	}

	public override void Reset(){ 


		if(attacker == null){
			attacker = GameObject.Find("Attacker Holder"); 
		}

		rb = GetComponent<Rigidbody> ();
		tr = GetComponent<TrailRenderer> ();

		float offSetX = 3;
		float offSetY = 2;
		transform.position = new Vector3 (attacker.transform.position.x + offSetX, attacker.transform.position.y + offSetY, 0);

		rb.velocity = Vector3.zero; 
		tr.Clear();

	}

	public void OnCollisionEnter (Collision coll){


		GameObject impact = ObjectPooling.GetFromPool("Impact");

		impact.GetComponent<PoolableImpact> ().EmitParticles (coll.transform.position);

		Destroy (coll.gameObject);
		ObjectPooling.AddToPool (gameObject);





	}
}
