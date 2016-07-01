using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon : MonoBehaviour
{
	public GameObject prefab;
	public Projectile projectile;
	public int projectileCount;
	public bool ready;
	public float fireRate;
	public int capacity;
	public int rotateSpeed;
	public Transform openingLocation;
	public Transform target;

}

