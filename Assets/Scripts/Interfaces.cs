using UnityEngine;
using System.Collections;

	public interface IInventory {
		//
	}

	public interface IDamageable {
		void TakeDamage(int amount);
		//adjusthealth should listen?
	}

	public interface IKillable {
		void IsDead();
	}

	public interface ICharacterPhysics {
		void Move(float horizontal);
		void GroundCheck(MovementProperties moveProperty);
		void Jump();
		void Flip();
	}

	public interface IWeaponHandler {
		void Fire(Weapon weapon);
		void UpdateWeaponPosition(Weapon weapon, float vertical, LookPoints lookPoints);
		void SwitchWeapon();
		void SwitchProjectile();
	}

	public interface IAnimationHandler {
		
	}
	
