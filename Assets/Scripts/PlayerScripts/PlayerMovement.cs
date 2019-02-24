using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

	public float horizontal;
	public float moveSpeed;
	public static float originalMoveSpeed; //a static float that holds the original speed set for the player game object
	
	
	
	public float jump; //the input jump axis goes from 0 (not pressing jump) to 1 (pressing jump)
	[Range(1,30)]
	public float jumpForce; //upcoming fighting game starring Shohnen Jump characters
	
	
	public bool grounded;
	public bool leftSideCollision; //I have no idea what these are doing
	public bool rightSideCollision;


	private Rigidbody2D rb;

	public LayerMask groundDetectionLayer; //the layermask to detect ground
	public float groundRadius; //the radius of the ground detection THE DEFAULT is 0.2f
	public Transform groundPoint;//the point at which mim's feet are detected 

	public Animator anim;

	public SpriteRenderer[] spritesToFlip; //array of all the sprites that need to be flipped

	public static bool canClimb; //Mim is within the trigger of a climbable object
	public static bool isClimbing; //Mim is climbing - static bool
	public bool _isClimbing; //Mim is climbing, non static

	public float gravityScale; //saves the player rigidbody's gravity scale

	public float longFallThreshold; //the time after which long fall is initiated
	public float timeFalling; //how long Mim has been airborne

	private void Awake()
	{
		originalMoveSpeed = moveSpeed;
	}

	// Use this for initialization
	void Start ()
	{

		anim = this.GetComponent<Animator>();
		rb = this.GetComponent<Rigidbody2D>();
		gravityScale = rb.gravityScale;
	}
	
	// Update is called once per frame
	void Update ()
	{

		_isClimbing = isClimbing;
		moveSpeed = PlayerStats.moveSpeed;
		horizontal = Input.GetAxisRaw("Horizontal");
		jump = Input.GetAxisRaw("Jump");
		
	}

	private void FixedUpdate()
	{	
		
		grounded = Physics2D.OverlapCircle(groundPoint.transform.position,groundRadius,groundDetectionLayer);
		
		if (PlayerStats.isInteractive==true)
		{
			
			
			
			if (isClimbing == true && (grounded==false || Input.GetAxisRaw("Vertical")!=0 || Input.GetAxisRaw("Horizontal")!=0))
			{
				Climb();
			}
			else
			{
				Move();	
			}
			
		}
		else
		{
			Debug.Log("Player can't move");
		}
		
		Jump();
		SetAnimationStage();

		if (Input.GetKeyDown(KeyCode.E)) //stop climbing
		{
			isClimbing = false;
			rb.gravityScale = gravityScale;
		}

		NormalizeSlope();
		
		
	}

	void Move()
	{
		anim.SetBool("isClimbing",false);

		
		if (Input.GetAxisRaw("Horizontal") != 0)
		{
			//rb.constraints = RigidbodyConstraints2D.None;
			
			anim.SetBool("isWalking",true);
			
			rb.velocity =
				new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * moveSpeed, 0.8f), rb.velocity.y);

			
			

			if (Input.GetAxisRaw("Horizontal") > 0)
			{
				//this.transform.Find("MimSprite").GetComponent<SpriteRenderer>().flipX = false;

				foreach (SpriteRenderer _sprite in spritesToFlip)
				{
					_sprite.flipX = false;
				}
				
				
			}else if (Input.GetAxisRaw("Horizontal") < 0)
			{
				//this.transform.Find("MimSprite").GetComponent<SpriteRenderer>().flipX = true;
				foreach (SpriteRenderer _sprite in spritesToFlip)
				{
					_sprite.flipX = true;
				}
			}
			
			Debug.Log("Moving");
			
		}

		else
		{
			//rb.constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezePositionX|RigidbodyConstraints2D.FreezeRotation;

			float horizontalSpeed=0;
			DOTween.To(()=> horizontalSpeed, x=> horizontalSpeed = x, 0, 1);
			
			anim.SetBool("isWalking",false);
			
			rb.velocity = new Vector2(horizontalSpeed,rb.velocity.y);
	
			Debug.Log("Not moving");
		}
	}

	public void Climb()
	{
		anim.SetBool("isClimbing",true);
		
		rb.gravityScale = 0;
		
		if (Input.GetAxisRaw("Vertical") != 0||Input.GetAxisRaw("Horizontal") != 0)
		{
			//rb.constraints = RigidbodyConstraints2D.None;
			//rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			Debug.Log("The Climb is all there is");

			rb.constraints = RigidbodyConstraints2D.None;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			
			
			rb.velocity =
				new Vector2( Input.GetAxis("Horizontal") * moveSpeed,Mathf.Lerp(0, Input.GetAxis("Vertical") * moveSpeed, 0.8f));
			
			//rb.velocity = new Vector2(0,10f);
		}
		else
		{
			Debug.Log("Stopped climbing");
			rb.velocity = Vector2.zero;
			rb.constraints = RigidbodyConstraints2D.FreezePositionY;

			//rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}
		
		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			//this.transform.Find("MimSprite").GetComponent<SpriteRenderer>().flipX = false;

			foreach (SpriteRenderer _sprite in spritesToFlip)
			{
				_sprite.flipX = false;
			}
				
				
		}else if (Input.GetAxisRaw("Horizontal") < 0)
		{
			//this.transform.Find("MimSprite").GetComponent<SpriteRenderer>().flipX = true;
			foreach (SpriteRenderer _sprite in spritesToFlip)
			{
				_sprite.flipX = true;
			}
		}

	}

	
	
	public void Jump()
	{
		if (isClimbing == true && Input.GetAxisRaw("Vertical")>0)
		{
			grounded = false;
		}
		
		if (grounded == true)
		{
			rb.velocity = new Vector2(rb.velocity.x, jump * jumpForce);

			if (jump > 0)
			{
				anim.SetBool("isJumping",true);
			}

			if (Input.GetAxisRaw("Vertical") < 0)
			{
				isClimbing = false;

			}
			
			//rb.velocity = Vector2.up * jumpForce*jump;
		}
		else if(jump>0)
		{
			//anim.SetBool("isJumping",true);
		}
		else if(rb.velocity.y<=0)
		{
			anim.SetBool("isJumping", false);
		}
		else
		{
			if (jump == 0)
			{
				anim.SetBool("isJumping", false);
			}
			
		}

		
		
		
	}

	/*public IEnumerator Landed()
	{
		yield return new WaitForSeconds(0.1f);
		bool isJumping = anim.GetBool("isJumping");
		if (isJumping == true && grounded == true)
		{
			anim.SetBool("isJumping", false);
		}
	}*/ //not being used
	
	public void SetAnimationStage()
	{
		
		if (grounded == false)
		{
			timeFalling += Time.deltaTime;
			if (rb.velocity.y !=0 && jump == 0 && timeFalling>0.11f) //if you haven't pressed the jump button or if you are not on ground
			{
				anim.SetBool("isFalling", true);
				
				anim.SetFloat("timeFallen",timeFalling);

				if (timeFalling > longFallThreshold)
				{
					anim.SetBool("longFall", true);
				}
				
			}
			
		}
		else
		{
			anim.SetBool("isFalling", false);
			timeFalling = 0;
			anim.SetFloat("timeFallen",timeFalling);
			if (anim.GetBool("longFall") == true)
			{
				//HardLanding(); //disabled it cause it was causing a lot of issues
			}
			
			
			
		}
	}

	public void HardLanding()
	{
		Debug.Log("Freeze movement");
		PlayerStats.isInteractive = false;
		moveSpeed = 0;
		rb.velocity = new Vector2(0,0);
		moveSpeed = 0;
	}

	public void DisableMovement()
	{
		Debug.Log("Freeze movement");
		PlayerStats.isInteractive = false;
		rb.velocity = new Vector2(0,0);
		moveSpeed = 0;
	}
	public void EnableMovement()
	{
		PlayerStats.isInteractive = true;
		moveSpeed = originalMoveSpeed;
		anim.SetBool("longFall", false);
	}
	
	void NormalizeSlope () {
		// Attempt vertical normalization
		if (grounded) {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, groundDetectionLayer);
         
			if (hit.collider != null && Mathf.Abs(hit.normal.x) > 0.1f) {
				Rigidbody2D body = GetComponent<Rigidbody2D>();
				// Apply the opposite force against the slope force 
				// You will need to provide your own slopeFriction to stabalize movement
				body.velocity = new Vector2(body.velocity.x - (hit.normal.x * 20), body.velocity.y);
 
				//Move Player up or down to compensate for the slope below them
				Vector3 pos = transform.position;
				pos.y += -hit.normal.x * Mathf.Abs(body.velocity.x) * Time.deltaTime * (body.velocity.x - hit.normal.x > 0 ? 1 : -1);
				transform.position = pos;
			}
		}
	}
}
