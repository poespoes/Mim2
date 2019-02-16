using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

	public float horizontal;
	public float moveSpeed;
	public static float originalMoveSpeed; //a static float that holds the original speed set for the player game object
	
	public float jump;
	[Range(1,30)]
	public float jumpForce;
	
	
	public bool grounded;
	public bool leftSideCollision;
	public bool rightSideCollision;


	private Rigidbody2D rb;

	public LayerMask groundDetectionLayer;
	public float groundRadius;
	public Transform groundPoint;

	public Animator anim;

	public SpriteRenderer[] spritesToFlip; //array of all the sprites that need to be flipped

	public static bool canClimb;
	public static bool isClimbing;
	public bool _isClimbing;

	public float gravityScale;


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
		
		Jump();
		SetAnimationStage();

		if (Input.GetKeyDown(KeyCode.E)) //stop climbing
		{
			isClimbing = false;
			rb.gravityScale = gravityScale;
		}
		
		
		
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
		
		
		if (grounded == true)
		{
			rb.velocity = new Vector2(rb.velocity.x, jump * jumpForce);

			if (jump > 0)
			{
				anim.SetBool("isJumping",true);
			}

			isClimbing = false;

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
		
	}
	
	public void SetAnimationStage()
	{
		if (grounded == false)
		{
			if (rb.velocity.y < -2f)
			{
				anim.SetBool("isFalling", true);
			}
			
		}
		else
		{
			anim.SetBool("isFalling", false);
		}
	}
	
}
