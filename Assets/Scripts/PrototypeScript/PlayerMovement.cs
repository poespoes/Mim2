using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

	public float moveSpeed;
	float myFloat;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		Move();
	}

	void Move()
	{
		if (Input.GetAxisRaw("Horizontal") != 0)
		{
			//this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			
			
			this.GetComponent<Rigidbody2D>().velocity =
				new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * moveSpeed, 0.8f), this.GetComponent<Rigidbody2D>().velocity.y);

			
			

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
			//this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezePositionX|RigidbodyConstraints2D.FreezeRotation;

			float myFloat=0;
			DOTween.To(()=> myFloat, x=> myFloat = x, 0, 1);
			
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(myFloat,this.GetComponent<Rigidbody2D>().velocity.y);


		}
	}
}
