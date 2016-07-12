using UnityEngine;
using System.Collections;

public interface IDamageable
{
	void TakeDamage (int amount);
}

public interface IKillable
{
	void IsDead ();
}

public interface ICharacterPhysics
{
	void Move (float horizontal);

	void GroundCheck (MovementProperties moveProperty);

	void Jump ();

	void Flip ();
}
	

public interface IWeaponHandler
{

	void UpdateLookDirection (Weapon weapon, float vertical, LookPoints lookPoints);

	void SwitchWeapon ();

	void SwitchProjectile ();
}

public interface IAnimationHandler
{
		
}
	
