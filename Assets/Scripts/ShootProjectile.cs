using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {


	public Projectile projectile;
	public Transform openingLocation;
	public Transform target;
	// Use this for initialization
	void Start () {
	}	
	
	// Update is called once per frame
//	void Update () {
//		}
	void FixedUpdate(){
		if (Input.GetButtonDown("ShootArrow")) {
			Projectile clone;
			clone = Instantiate(projectile, openingLocation.position, openingLocation.rotation) as Projectile;	//creates the arrow on click, at the cannon opening
			Rigidbody2D projectileRB = clone.GetComponent<Rigidbody2D>();
			Vector3 relativePos = target.position - clone.transform.position;
			projectileRB.AddForce(relativePos * 1000);
		}

	}
}
