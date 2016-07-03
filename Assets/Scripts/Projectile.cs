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

	void Start () {

		this.isGrounded = false;
		this.speed = 1000; 
		this.damage = 50;
		collider2d = GetComponent<PolygonCollider2D>();
		var characterHandle = GetComponentInParent<Character>();
		//this.playerNumber = characterHandle.playerNumber; 	//hard coded must think of a way to grab
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if(collider.gameObject.tag == "Player"){
			EventManagerIntArg.TriggerEvent("ArrowCollide", damage);
			Destroy(transform.gameObject);
		}
	}
}