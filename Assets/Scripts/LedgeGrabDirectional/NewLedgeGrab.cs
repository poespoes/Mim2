using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Cinemachine.Examples;
using DG.Tweening;
using UnityEngine;

public class NewLedgeGrab : MonoBehaviour
{

	public bool canGrab;
	public GameObject ledge;
	public GameObject player;
	public bool isGrabbing;

	public bool isActive;
	public Mantle mantle;
	

	// Use this for initialization
	void Start ()
	{
		canGrab = false;
		player = this.transform.parent.gameObject;
		isGrabbing = false;
		mantle = player.GetComponent<Mantle>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		//GrabEdge();

		if (isGrabbing == true)
		{
			if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Vertical"))
			{
				PullUp();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (isActive == true)
		{
			if (player.GetComponent<Player>().canJump == false)
			{
				if (other.CompareTag("grabLedge"))
				{
					Debug.Log("Can grab this ledge");
					canGrab = true;

					ledge = other.gameObject;
					GrabEdge();
				}
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		
		

	}

	private void GrabEdge()
	{
		if (isActive == true)
		{
			if (canGrab == true)
			{
				if (player.GetComponent<Player>().canJump == false)
				{
					isGrabbing = true;
					player.GetComponent<Player>().canJump = false;
					
					player.GetComponent<Animator>().Play("MimLedgeGrab");
					player.GetComponent<PlayerAnimation>().WalkingState = 6;


					//player.transform.position = ledge.GetComponent<Ledge>().grabPos.position;
					player.transform.DOMove(ledge.GetComponent<Ledge>().grabPos.position, 0.5f);
					
					player.GetComponent<Rigidbody2D>().constraints =
						RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX |
						RigidbodyConstraints2D.FreezeRotation;
					GameObject.Find("GameManager").GetComponent<gameState>().interactive = false;


					if (Input.GetButtonDown("Jump")||Input.GetButtonDown("Vertical"))
					{
						PullUp();
					}

				}
			}
		}
	}

	private void PullUp()
	{
		
		//isGrabbing = false;
		player.GetComponent<Mantle>().MantleStart(ledge.GetComponent<Ledge>().getUpPos);
		//GameObject.Find("GameManager").GetComponent<gameState>().interactive = true;
		//canGrab = false;
		//ledge = null;
		
		
		
		//player.transform.position = ledge.GetComponent<Ledge>().getUpPos.position;

		//player.transform.position = transform.DoMove(ledge.GetComponent<Ledge>().getUpPos.position, 0.5f);

		//player.transform.DOMove(ledge.GetComponent<Ledge>().getUpPos.position, 0.5f);
		
		
		


		
	}
}
