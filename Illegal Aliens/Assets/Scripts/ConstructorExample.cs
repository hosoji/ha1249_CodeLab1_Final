using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorExample {

	//Script made in Class
	//Edit for your own purposes, dont get confused on why its here

	public float temp;
	public string name;
	public GameObject gameObject;
	public int num;
	public bool isLoaded;

	//Creating Constructors
	public ConstructorExample(){
		Debug.Log ("Made a loader");

		temp = 10;
		name = "No Name";
		num = 11;
		isLoaded = false;
	}

	public ConstructorExample (float _temp, string _name){
		temp = _temp;
		name = _name;
	}

//
//	public Loader (float temp, string name){
//		this.temp = temp;
//		this.name = name;
//	}
//
}
