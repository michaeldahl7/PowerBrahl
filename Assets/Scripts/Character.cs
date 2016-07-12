using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class Character : MonoBehaviour, IDamageable, IKillable {


	public WeaponProperties weaponProperties;
	public MovementProperties movementProperties;
	public HealthProperties healthProperties;
	public int playerNumber;
	public SpriteRenderer playerAvatar;
	public Rigidbody2D rigidbody2d;
	public LookPoints lookPoints;
	[System.NonSerialized]
	public bool facingRight = true;
	public Animator anim;


	public void TakeDamage(int amount)
	{
		healthProperties.currentHealth -= amount;
		IsDead();
	}
	public void IsDead()
	{
		if(healthProperties.currentHealth <= 0)
		{
			healthProperties.isDead = true;
			//player dead
		}
	}

	void ArrowPickup(int amount)
	{
		weaponProperties.weapon.projectileCount += amount;
		Debug.Log(weaponProperties.weapon.projectileCount);
	}

	void OnEnable()
	{
		EventManagerIntArg.StartListening("ArrowCollide", TakeDamage);
		EventManagerIntArg.StartListening("ArrowPickup", ArrowPickup);
	}

	void OnDisable()
	{
		EventManagerIntArg.StopListening("ArrowCollide", TakeDamage);
		EventManagerIntArg.StopListening("ArrowPickup", ArrowPickup);
	}
}
	
[System.Serializable]
public class MovementProperties 
{
	public float movementSpeed;
	public float turnSpeed;
	public Transform groundCheck;
	public float groundRadius;
	public LayerMask whatIsGround;
	public bool isGrounded;
	public float jumpForce;
	public int jumpCount;
	public int numOfJumps;
	public int maxSpeed;
}

[System.Serializable]
public class HealthProperties 
{
	public float maxHealth;
	public float regenerationRate;
	public float currentHealth;
	public bool isDead;
}

[System.Serializable]
public class WeaponProperties 
{
	public Weapon weapon;
	public bool isWeaponEquipped;
}