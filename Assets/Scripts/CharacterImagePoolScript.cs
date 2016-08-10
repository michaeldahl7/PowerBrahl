using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterImagePoolScript : MonoBehaviour {

	public static CharacterImagePoolScript current;
	public HeroImageObject pooledObject;
	public int pooledAmount;
	//public bool willGrow; not for arrays

	public HeroImageObject[] pooledObjects;

	void Awake ()
	{
		current = this;
	}
	// Use this for initialization
	void Start ()
	{
		pooledObjects = new HeroImageObject[pooledAmount];
		for (int i = 0; i < pooledObjects.Length; i++) {
			HeroImageObject obj = (HeroImageObject)Instantiate (pooledObject);
			obj.gameObject.SetActive (false);
			pooledObjects [i] = obj;
		}
	}

	public HeroImageObject getPooledProjectile ()
	{
		for (int i = 0; i < pooledObjects.Length; i++) {
			if (!pooledObjects [i].isActiveAndEnabled) {
				return pooledObjects [i];
			}
		}
		return null;
	}
}
