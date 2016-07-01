using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroController : MonoBehaviour, ICharacterPhysics, IWeaponHandler
{
	public Character character;
    public RectTransform arrowDisplayPanel;
    public PowerBrahlManager PBmanager;

	public void Move(float horizontal)
	{
		character.rigidbody2d.AddForce(new Vector2(horizontal * character.movementProperties.movementSpeed,0));
		if (horizontal > 0 && !character.facingRight)
			Flip ();
		else if (horizontal < 0 && character.facingRight) {
			Flip ();
		}
	}
	public void GroundCheck(MovementProperties moveProperty){
		moveProperty.isGrounded = Physics2D.OverlapCircle (moveProperty.groundCheck.position, moveProperty.groundRadius, moveProperty.whatIsGround);
        if (moveProperty.isGrounded)     //Resets jumpcount when player touches back down.
        {
            moveProperty.jumpCount = 0;
        }
		character.anim.SetBool ("Ground", moveProperty.isGrounded);
	}
	public void Jump ()
	{
		if (character.movementProperties.jumpCount < character.movementProperties.numOfJumps)
        {
            character.anim.SetBool("Ground", false);
			character.rigidbody2d.AddForce(new Vector2(0, character.movementProperties.jumpForce));
            character.movementProperties.jumpCount++;
        }
	}

	public void Flip(){
				character.facingRight = !character.facingRight;
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
	}

//	// Update is called once per frame
	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		Move(horizontal);
		GroundCheck(character.movementProperties);

		if (Input.GetButtonDown ("Jump")) {
			Jump ();
		}

		if (Input.GetButtonDown("ShootArrow")) {
				Fire(character.weaponProperties.weapon);
		}

		UpdateWeaponPosition(character.weaponProperties.weapon, vertical, character.lookPoints);
		
//
//		anim.SetFloat ("vSpeed", Body.velocity.y);
//		anim.SetFloat ("Speed", Mathf.Abs (horizontal));


//		if(healthBarImage){
//			healthBarImage.transform.position = abovePoint.position;
//		}
	}

	public void Fire(Weapon weapon)
	{
		if(weapon != null){
				Projectile clone;
				clone = Instantiate(weapon.projectile, weapon.openingLocation.position, weapon.openingLocation.rotation) as Projectile;	//creates the arrow on click, at the cannon opening
				Rigidbody2D projectileRB = clone.GetComponent<Rigidbody2D>();
				Vector3 relativePos = weapon.target.position - clone.transform.position;
				projectileRB.AddForce(relativePos * clone.speed);
		}
	}
	public void UpdateWeaponPosition(Weapon weapon, float vertical, LookPoints lookPoints){
		if(weapon != null){
			if (.55 > vertical && vertical > .10) {
				weapon.transform.position = Vector3.Lerp (weapon.transform.position, lookPoints.upperRightPoint.position, 1);
				weapon.transform.rotation = Quaternion.Slerp (weapon.transform.rotation, lookPoints.upperRightPoint.rotation, Time.deltaTime * weapon.rotateSpeed);
			} else if (vertical >= .55) {
				weapon.transform.position = Vector3.Lerp (weapon.transform.position, lookPoints.abovePoint.position, 1);
				weapon.transform.rotation = Quaternion.Slerp (weapon.transform.rotation, lookPoints.abovePoint.rotation, Time.deltaTime * weapon.rotateSpeed);
			} else if (-.10 >= vertical && vertical >= -1) {
				weapon.transform.position = Vector3.Lerp (weapon.transform.position, lookPoints.bottomRightPoint.position, 1);
				weapon.transform.rotation = Quaternion.Slerp (weapon.transform.rotation, lookPoints.bottomRightPoint.rotation, Time.deltaTime * weapon.rotateSpeed);
			} else {
				weapon.transform.position = Vector3.Lerp (weapon.transform.position, lookPoints.rightPoint.position, 1);
				weapon.transform.rotation = Quaternion.Slerp (weapon.transform.rotation, lookPoints.rightPoint.rotation, Time.deltaTime * weapon.rotateSpeed);
			}
		}
	}
	public void SwitchWeapon(){
		
	}
	public void SwitchProjectile(){
		
	}
		
//
//	void Update ()
//	{
//		if (Input.GetButtonDown (jumpString)) {
//			Jump ();
//		}
//		if (Input.GetButtonDown ("LinkMelee")) {
//			Attack ();
//		}
//		if (Input.GetButtonDown ("LinkBlock")) {
//			Block ();
//		}
//		if (Input.GetButtonUp ("LinkBlock")) {
//			anim.SetBool ("Block", false);
//		}
//		if (Input.GetButtonDown ("LinkSpin")) {
//			SpinAttack ();
//		}
//	}
//

//

//
//	void Attack ()
//	{
//		anim.SetTrigger ("OnAttack");
//	}
//
//	void Block ()
//	{
//		anim.SetBool ("Block", true);
//	}
//
//	void SpinAttack ()
//	{
//		anim.SetTrigger ("OnSpin");
//	}
//
//	void OnCollisionEnter2D(Collision2D collider){
//		if(collider.gameObject.tag == "Arrow"){
//			adjustHealth(arrowDamage);
//		}
//	}
//
//	void adjustHealth (float changeAmount)
//	{
//		playerHealth -= changeAmount;
//		Debug.Log(playerHealth);
//		updateHealthBar();
//	}
//
//	void updateHealthBar(){
//		healthBarImage.fillAmount = (playerHealth/100);
//	}
}
