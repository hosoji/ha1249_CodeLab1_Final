using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Poolable : MonoBehaviour {


	void Start(){
		Setup();
	}

	void Update () {
		if(RePool()){ 
			ObjectPooling.AddToPool(gameObject);
		}
	}

	public abstract void Setup();

	public abstract bool RePool();

	public abstract void Reset();
}
