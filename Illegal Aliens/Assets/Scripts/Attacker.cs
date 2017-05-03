using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Attacker : MonoBehaviour {

	Renderer []rend;

	protected Vector3 posMax;
	protected Vector3 posMin;

	protected float bulletWaitFactor = 0;

	protected float speed = 30f;

	protected float basePos = -27;

	protected float start;

	protected float xPosMin = -130;
	protected float xPosMax = 220;

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

	protected float t = 1f;

	// Use this for initialization
	void Start () {

		Setup ();

	}

	public virtual void Setup(){
		rend = GetComponentsInChildren<Renderer> ();

		for (int i = 0; i < rend.Length; i++) {
			rend [i].enabled = true;
			SetMaterial (rend [i]);
		}
	}

	public void PositionUpdate(float f, float min, float max){
		start = f;
		End =  Random.Range (min, max);
		t = 0f;
	}

	void ShootBullet(){

		GameObject bullet = ObjectPooling.GetFromPool("Bullet");

		Debug.Log ("GameObject Shooting is : " + gameObject.name);

//		bullet.transform.SetParent(this.transform);

		float offSetX = 3;
		float offSetY = 2;

		bullet.transform.position = new Vector3 (this.transform.position.x + offSetX, this.transform.position.y + offSetY, this.transform.position.z);
		bullet.transform.parent = this.transform;

	}

	public void InvertAttacker(){
		basePos = 110;
//		transform.Rotate (0, 0, 180);
		Vector3 pos = new Vector3 (transform.position.x, basePos, transform.position.z);
		transform.SetPositionAndRotation(pos, Quaternion.Euler(0, 0, 180));

	}



	public abstract void SetMaterial (Renderer rend);
		
		
}
