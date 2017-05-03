using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontPlaneAttacker : Attacker {


	// Use this for initialization
	void Start () {
		Setup ();

	}

	public override void Setup (){
		base.Setup ();
		bulletWaitFactor = 0.5f;
	
		speed = 30f;
		basePos = -27;

		posMin = new Vector3 (transform.position.x + xPosMin, basePos, -10);
		posMax = new Vector3 (transform.position.x + xPosMax, basePos, -10);


		InvokeRepeating ("ShootBullet", 1f, bulletWaitFactor);

	}

	// Update is called once per frame
	void Update () {
		Vector3 dir = new Vector3(End, basePos,-10) - transform.position;

		dir.Normalize();

		transform.position += dir * speed * Time.deltaTime;


		t += 1f * Time.deltaTime;

		if (t > 1.0f) {
			PositionUpdate(transform.position.x,posMin.x, posMax.x);
		}

	}

	public override void SetMaterial(Renderer rend){

		Material mat = Resources.Load("Materials/Bright", typeof(Material)) as Material;

		rend.sharedMaterial = mat;

	}
}
