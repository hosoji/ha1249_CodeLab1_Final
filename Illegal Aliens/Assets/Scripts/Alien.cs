using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Alien : MonoBehaviour {

	Renderer []rend;

//	protected string name = "Alien";

	void Start(){
		Setup ();

		}

	public virtual void Setup(){
		rend = GetComponentsInChildren<Renderer> ();

		for (int i = 0; i < rend.Length; i++) {
			rend [i].enabled = true;
			SetMaterial (rend [i]);
		}
		
	}

	public abstract void SetPlane (Vector3 pos);

	public abstract void SetMaterial (Renderer rend);
		
		
}
