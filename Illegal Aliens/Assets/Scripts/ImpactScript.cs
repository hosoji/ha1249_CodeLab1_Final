using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactScript : MonoBehaviour {



	void Start(){

	}


		
	public void EmitParticles(Vector3 pos, bool ready){

		GameObject myGameOject = Resources.Load ("Prefabs/Impact") as GameObject;

		GameObject impact = Instantiate (myGameOject, pos, Quaternion.identity);

		ParticleSystem ps = impact.GetComponent<ParticleSystem> ();
		
		if (ready) {
			ps.Play ();
			Camera.main.GetComponent<ScreenShakeScript> ().Shaker (0.03f); 
//			Debug.Log ("Particles?");
		}
		ready = false;
	}
}
