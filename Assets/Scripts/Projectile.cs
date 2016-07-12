using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Projectile : MonoBehaviour
{
	public int speed;
	public GameObject prefab;
	public Rigidbody2D rigidBody;
	public PolygonCollider2D collider2d;
	public int damage;
	public int playerNumber;
	public bool isGrounded;

	void Start ()
	{

		this.isGrounded = false;
		this.speed = 1000; 
		this.damage = 50;
		rigidBody = GetComponent<Rigidbody2D> ();
		collider2d = GetComponent<PolygonCollider2D> ();
		//var characterHandle = GetComponentInParent<Character> ();
		//this.playerNumber = characterHandle.playerNumber; 	//hard coded must think of a way to grab
	}

	void OnCollisionEnter2D (Collision2D collider)
	{
		switch (collider.gameObject.tag) {
		case "Player":
			if (this.isGrounded) {	
				this.gameObject.SetActive(false);
				EventManagerIntArg.TriggerEvent ("ArrowPickup", 1);
				break;
			}
			this.gameObject.SetActive(false);
			EventManagerIntArg.TriggerEvent ("ArrowCollide", damage);
			break;
		default: 
			break;
		}	
	}

	void OnCollisionStay2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground") {
			if (this.rigidBody.velocity.y == 0 && this.rigidBody.velocity.x == 0) {
				this.isGrounded = true;
				Debug.Log ("Grounded");
			}
		}
			

	}
}