using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class ChromaAdjuster : MonoBehaviour {

	VignetteAndChromaticAberration effect;

	// Use this for initialization
	void Start () {
		effect = gameObject.GetComponent<VignetteAndChromaticAberration> ();
	}

	public void EffectOn(){

		if (!effect.enabled) {
			effect.enabled = true;
			Invoke ("EffectOff", Random.Range(0.1f,0.3f));
		}
	}

	public void EffectOff(){
		effect.enabled = false;
	}
}
