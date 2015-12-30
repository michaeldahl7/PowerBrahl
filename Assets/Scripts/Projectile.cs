using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

	public int projectileSpeed = 50;
	public Rigidbody2D rigidBody;
	// Use this for initialization
	void Start ()
	{
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//transform.rotation = Quaternion.LookRotation(rigidBody.velocity);
	}

	void OnCollisionEnter2D (Collision2D collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			Debug.Log ("this was reached");
			Destroy (gameObject);
		}
	}


}
