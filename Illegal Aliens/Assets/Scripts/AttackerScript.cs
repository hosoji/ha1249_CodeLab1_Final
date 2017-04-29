using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerScript : MonoBehaviour {

	Vector3 posMin = new Vector3 (-58, -27, 0);
	Vector3 posMax = new Vector3 (55, -27, 0);
//	[SerializeField] float speed = 5;
	[SerializeField] float bulletWaitFactor = 0.5f;

	public float speed = 30f;

	float yPos = -27;

	float start;

	private float end;


	public float End{
		get{
			return end;
		}

		set{
			end = value;

			if (end >= posMax.x) {
				end = posMax.x;
			}

			if (end <= posMin.x) {
				end = posMin.x;
			}
		}
	}

	static float t = 1f;

	GameObject bullet;

	// Use this for initialization
	void Start () {
		
		bullet = Resources.Load("Prefabs/Bullet") as GameObject;
		InvokeRepeating ("ShootBullet", 1f, bulletWaitFactor);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 dir = new Vector3(end, yPos,0) - transform.position;

		dir.Normalize();

		transform.position += dir * speed * Time.deltaTime;


		t += 1f * Time.deltaTime;

		if (t > 1.0f) {
			PositionUpdate();
		}
		
	}

	void PositionUpdate(){

		start = transform.position.x;
		End =  Random.Range (posMin.x, posMax.x);
		t = 0f;
	}

	void ShootBullet(){
		float offSetX = 3;
		float offSetY = 2;
		Vector3 bulletPos = new Vector3 (transform.position.x + offSetX, transform.position.y + offSetY, 0);
		Instantiate (bullet, bulletPos, Quaternion.identity);
	}
		
		
}
