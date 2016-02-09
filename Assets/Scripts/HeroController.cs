using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroController : MonoBehaviour
{
	public float maxSpeed;
	private bool facingRight = true;
	Rigidbody2D Body;
	Animator anim;
	bool isGrounded = false;
	public Transform groundCheck;
	float groundRadius = .1f;
	public LayerMask whatIsGround;
	public float jumpForce;
	public Transform abovePoint;            //point for direction to snap to
	public Transform belowPoint;
	public Transform upperRightPoint;
	public Transform bottomRightPoint;
	public Transform rightPoint;
	public Transform bow;
	public bool bowEquipped;
	public Transform bowOpeningLocation;
	public int playerNumber;
	private string horizontalString;        //horizontal input string for determining multiple player input SEE determineCharacterInput method
	private string jumpString;              //jump string for input
	private float attackCoolDown;
	public float playerHealth = 100;
	private bool isDead = false;
    public int bowRotateSpeed = 5;
	public float arrowDamage = 2;
	public Image healthBarImage;
    private int jumpCount;
    private int arrowMax = 5;
    private int currentArrowAmount = 5;
    public RectTransform arrowDisplayPanel;
    public PowerBrahlManager PBmanager;


    // Use this for initialization
    void Start ()
	{
        PBmanager = GetComponent<PowerBrahlManager>();
		//healthBarImage = healthBarGameObject.GetComponent<Image>();
		Body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		determineCharacterInput ();
		if (bow != null) {
			bowEquipped = true;
		}
	}

	void determineCharacterInput ()
	{
		if (playerNumber == 1) {
			horizontalString = "Horizontal";
			jumpString = "Jump";
		} else if (playerNumber == 2) {
			horizontalString = "ShieldHorizontal";
			jumpString = "ShieldJump";
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
        if (isGrounded)     //Resets jumpcount when player touches back down.
        {
            jumpCount = 0;
        }
        Debug.Log("Grounded: " + isGrounded);
		anim.SetBool ("Ground", isGrounded);

		anim.SetFloat ("vSpeed", Body.velocity.y);
	
		float horizontal = Input.GetAxis (horizontalString);
		float vertical = Input.GetAxis ("Vertical");
		anim.SetFloat ("Speed", Mathf.Abs (horizontal));
		Body.velocity = new Vector2 (horizontal * maxSpeed, Body.velocity.y);

		if(bowEquipped){
			UpdateBowPosition(horizontal, vertical);
		}

		if (horizontal > 0 && !facingRight)
			Flip ();
		else if (horizontal < 0 && facingRight) {
			Flip ();
			Quaternion tempRotation = new Quaternion ();		//Adjust bows rotation of flip
			tempRotation = bowOpeningLocation.rotation;			//
			tempRotation.z += 220;								//
			bowOpeningLocation.rotation = tempRotation;			//
		}
		if(healthBarImage){
			healthBarImage.transform.position = abovePoint.position;
		}
	}

	void UpdateBowPosition(float horizontal, float vertical){
		if (bow != null && bowEquipped) {
			if (.55 > vertical && vertical > .10) {
				bow.transform.position = Vector3.Lerp (bow.transform.position, upperRightPoint.position, 1);
				bow.transform.rotation = Quaternion.Slerp (bow.transform.rotation, upperRightPoint.rotation, Time.deltaTime * bowRotateSpeed);
				;
			} else if (vertical >= .55) {
				bow.transform.position = Vector3.Lerp (bow.transform.position, abovePoint.position, 1);
				bow.transform.rotation = Quaternion.Slerp (bow.transform.rotation, abovePoint.rotation, Time.deltaTime * bowRotateSpeed);
			} else if (-.10 >= vertical && vertical >= -1) {
				bow.transform.position = Vector3.Lerp (bow.transform.position, bottomRightPoint.position, 1);
				bow.transform.rotation = Quaternion.Slerp (bow.transform.rotation, bottomRightPoint.rotation, Time.deltaTime * bowRotateSpeed);
			} else {
				bow.transform.position = Vector3.Lerp (bow.transform.position, rightPoint.position, 1);
				bow.transform.rotation = Quaternion.Slerp (bow.transform.rotation, rightPoint.rotation, Time.deltaTime * bowRotateSpeed);
			}
		}
	}

	void rotateTowards (Transform location, Transform target)
	{
		var newRotation = Quaternion.LookRotation (location.position - target.position);
		newRotation.x = 0.0f;
		newRotation.y = 0.0f;
		location.rotation = Quaternion.Slerp (location.rotation, newRotation, Time.deltaTime * 80000);
	}

	void Update ()
	{
		if (Input.GetButtonDown (jumpString)) {
			Jump ();
		}
		if (Input.GetButtonDown ("LinkMelee")) {
			Attack ();
		}
		if (Input.GetButtonDown ("LinkBlock")) {
			Block ();
		}
		if (Input.GetButtonUp ("LinkBlock")) {
			anim.SetBool ("Block", false);
		}
		if (Input.GetButtonDown ("LinkSpin")) {
			SpinAttack ();
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Jump ()
	{
        if (jumpCount < 1)
        {
            anim.SetBool("Ground", false);
            Body.AddForce(new Vector2(0, jumpForce));
            jumpCount++;
        }
	}

	void Attack ()
	{
		anim.SetTrigger ("OnAttack");
	}

	void Block ()
	{
		anim.SetBool ("Block", true);
	}

	void SpinAttack ()
	{
		anim.SetTrigger ("OnSpin");
	}

	void OnCollisionEnter2D(Collision2D collider){
		if(collider.gameObject.tag == "Arrow"){
			adjustHealth(arrowDamage);
		}
	}

	void adjustHealth (float changeAmount)
	{
		playerHealth -= changeAmount;
		Debug.Log(playerHealth);
		updateHealthBar();
	}

	void updateHealthBar(){
		healthBarImage.fillAmount = (playerHealth/100);
	}
}
