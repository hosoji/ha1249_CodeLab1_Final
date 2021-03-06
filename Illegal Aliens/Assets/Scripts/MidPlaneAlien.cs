﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidPlaneAlien : Alien {


	public override void SetPlane (Vector3 pos){
		transform.position = new Vector3 (pos.x, pos.y, 0);
	}

	public override void SetMaterial(Renderer rend){

		Material mat = Resources.Load("Materials/Neutral", typeof(Material)) as Material;

		rend.sharedMaterial = mat;

	}
}
