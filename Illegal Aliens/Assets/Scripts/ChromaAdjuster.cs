using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class ChromaAdjuster : MonoBehaviour {

	VignetteAndChromaticAberration effect;

	float rate = 1000;

	// Use this for initialization
	void Start () {
		effect = gameObject.GetComponent<VignetteAndChromaticAberration> ();
	}

	public void EffectOn(){

		if (!effect.enabled) {
			effect.enabled = true;
			Invoke ("EffectOff", 0.1f);

			effect.chromaticAberration *= rate;

		}
	}

	public void EffectOff(){
		effect.enabled = false;
	}
}
