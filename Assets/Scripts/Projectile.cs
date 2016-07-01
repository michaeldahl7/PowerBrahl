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

	void Start () {
		
		this.speed = 1000;
		this.damage = 50;
		collider2d = GetComponent<PolygonCollider2D>();
		this.playerNumber = 0; 	//hard coded must think of a way to grab
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if(collider.gameObject.tag == "Player"){
			EventManagerIntArg.TriggerEvent("ArrowCollide", damage);
		}
	}
}





