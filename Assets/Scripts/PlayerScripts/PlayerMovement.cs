﻿using System.Collections;
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

	public Animator anim;

	public SpriteRenderer[] spritesToFlip;


	
	// Use this for initialization
	void Start ()
	{

		anim = this.GetComponent<Animator>();
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
		
		if (PlayerStats.isInteractive==true)
		{
			Move();
		}
		
		Jump();
		
		
	}

	void Move()
	{
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
			
			
			
		}

		else
		{
			//rb.constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezePositionX|RigidbodyConstraints2D.FreezeRotation;

			float horizontalSpeed=0;
			DOTween.To(()=> horizontalSpeed, x=> horizontalSpeed = x, 0, 1);
			
			anim.SetBool("isWalking",false);
			
			rb.velocity = new Vector2(horizontalSpeed,rb.velocity.y);


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

			
			//rb.velocity = Vector2.up * jumpForce*jump;
		}
		else if(jump>0)
		{
			//anim.SetBool("isJumping",true);
		}
		else
		{
			anim.SetBool("isJumping", false);
		}
		
	}
}
