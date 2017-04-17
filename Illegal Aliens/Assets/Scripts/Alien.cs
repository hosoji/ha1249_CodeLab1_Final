using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Alien : MonoBehaviour {

	Renderer []rend;

//	protected string name = "Alien";

	void Start(){
		rend = GetComponentsInChildren<Renderer> ();

		for (int i = 0; i < rend.Length; i++) {
			rend [i].enabled = true;
			SetMaterial (rend[i]);

		}
	}

	public virtual void Ability(Vector3 pos){
		transform.position = new Vector3 (pos.x, pos.y, 10);
	
	}

	public virtual void Reset (Vector3 pos){
		transform.position = new Vector3 (pos.x, pos.y, 0);
	}

	public virtual void SetMaterial(Renderer rend){

		Material mat = Resources.Load("Materials/Dark", typeof(Material)) as Material;

		rend.sharedMaterial = mat;
		
	}
		
}
