using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectilePoolScript : MonoBehaviour
{

	public static ProjectilePoolScript current;
	public Projectile pooledObject;
	public int pooledAmount;
	//public bool willGrow; not for arrays

	public Projectile[] pooledObjects;

	void Awake ()
	{
		current = this;
	}
	// Use this for initialization
	void Start ()
	{
		pooledObjects = new Projectile[pooledAmount];
		for (int i = 0; i < pooledObjects.Length; i++) {
			Projectile obj = (Projectile)Instantiate (pooledObject);
			obj.gameObject.SetActive (false);
			pooledObjects [i] = obj;
		}
	}

	public Projectile getPooledProjectile ()
	{
		for (int i = 0; i < pooledObjects.Length; i++) {
			if (!pooledObjects [i].isActiveAndEnabled) {
				return pooledObjects [i];
			}
		}
		return null;
	}

}
