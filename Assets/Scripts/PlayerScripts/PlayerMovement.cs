using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

	public float horizontal;
	public float moveSpeed;
	public float jump;
	[Range(1,10)]
	public float jumpForce;
	
	
	public bool grounded;
	public bool leftSideCollision;
	public bool rightSideCollision;


	private Rigidbody2D rb;

	public LayerMask groundDetectionLayer;
	public float groundRadius;
	public Transform groundPoint;

	
	// Use this for initialization
	void Start ()
	{

		rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		horizontal = Input.GetAxisRaw("Horizontal");
		jump = Input.GetAxisRaw("Jump");
		
	}

	private void FixedUpdate()
	{	
		grounded = Physics2D.OverlapCircle(groundPoint.transform.position,groundRadius,groundDetectionLayer);
		Move();
		Jump();
		
		
	}

	void Move()
	{
		if (Input.GetAxisRaw("Horizontal") != 0)
		{
			//rb.constraints = RigidbodyConstraints2D.None;
			
			
			rb.velocity =
				new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * moveSpeed, 0.8f), rb.velocity.y);

			
			

			if (Input.GetAxisRaw("Horizontal") > 0)
			{
				this.transform.Find("MimSprite").GetComponent<SpriteRenderer>().flipX = false;
			}else if (Input.GetAxisRaw("Horizontal") < 0)
			{
				this.transform.Find("MimSprite").GetComponent<SpriteRenderer>().flipX = true;
			}
			
		}

		else
		{
			//rb.constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezePositionX|RigidbodyConstraints2D.FreezeRotation;

			float horizontalSpeed=0;
			DOTween.To(()=> horizontalSpeed, x=> horizontalSpeed = x, 0, 1);
			
			rb.velocity = new Vector2(horizontalSpeed,rb.velocity.y);


		}
	}

	public void Jump()
	{
		if (grounded == true)
		{
			rb.velocity = new Vector2(rb.velocity.x, jump * jumpForce);

			//rb.velocity = Vector2.up * jumpForce*jump;
		}
		
	}
}
