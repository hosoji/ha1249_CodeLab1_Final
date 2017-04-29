using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {

	public static Queue<GameObject> bulletPool = new Queue<GameObject>();
	public static Queue<GameObject> impactPool = new Queue<GameObject>();

	public static GameObject GetFromPool(string type){

		GameObject result;

		if (type == "Bullet") { 
			if (bulletPool.Count > 0) { 
				result = bulletPool.Dequeue (); 
			} else {
				result = Instantiate (Resources.Load ("Prefabs/Bullet")) as GameObject; 
			}
		} else {
			if (impactPool.Count > 0) { 
				result = impactPool.Dequeue (); 
			} else {
				result = Instantiate (Resources.Load ("Prefabs/Impact")) as GameObject; 
			}
		}
			
		result.SetActive(true); 
		result.GetComponent<Poolable>().Reset(); 

		return result;
	}

	public static void AddToPool(GameObject obj){ //Add an object to the pool
		obj.SetActive(false); //turn off the object

		Poolable p = obj.GetComponent<Poolable>(); //get this objects Poolable component

		if (p is PoolableBullet) {
			bulletPool.Enqueue (obj);
		} else if (p is PoolableImpact) { 
			impactPool.Enqueue (obj);
		} else { 
			Debug.Log("You have not implemented a pool for this type of Object");
		}
	}
}

