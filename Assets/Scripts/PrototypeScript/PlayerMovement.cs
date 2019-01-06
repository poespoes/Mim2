using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float moveSpeed;
	
	
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
			this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			
			this.GetComponent<Rigidbody2D>().velocity =
				new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * moveSpeed, 0.8f), 0);

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
			this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezePositionX|RigidbodyConstraints2D.FreezeRotation;
		}
	}
}
