using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableImpact : Poolable {

	ParticleSystem ps;

	public override void Setup ()
	{

	}

	public override bool RePool(){ 
		return false;
	}

	public override void Reset(){ 

		ps = GetComponent<ParticleSystem> ();

		transform.position = Vector3.zero;
		ps.Stop ();
	}


	public void EmitParticles(Vector3 pos){

		transform.position = pos;

		ps = GetComponent<ParticleSystem> ();

		ps.Play();
		Camera.main.GetComponent<ScreenShakeScript> ().Shaker (0.03f); 

		if (!ps.isPlaying) {
			ObjectPooling.AddToPool (gameObject);
		}

	}
}
