using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class Character : MonoBehaviour, IDamageable, IKillable {

	public WeaponProperties weaponProperties;
	public MovementProperties movementProperties;
	public HealthProperties healthProperties;
	public int playerNumber;
	public GameObject playerSprite;
	public Rigidbody2D rigidbody2d;
	public LookPoints lookPoints;
	[System.NonSerialized]
	public bool facingRight = true;
	public Animator anim;


	public void TakeDamage(int amount)
	{
		healthProperties.currentHealth -= amount;
		Debug.Log("Health is now :" + healthProperties.currentHealth);
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

	void OnEnable()
	{
		EventManagerIntArg.StartListening("ArrowCollide", TakeDamage);
	}

	void OnDisable()
	{
		EventManagerIntArg.StopListening("ArrowCollide", TakeDamage);
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




