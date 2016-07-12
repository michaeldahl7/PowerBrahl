using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon : MonoBehaviour
{
	public Projectile prefab;
	public Projectile projectile;
	public int projectileCount;
	public int projectileCapacity;
	public bool ready;
	public float fireRate;
	public float damage;
	public int rotateSpeed;
	public Transform openingLocation;
	public Transform target;
	public Projectile[] projectiles;

	public void Attack(){
		
	}
}






