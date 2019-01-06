using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeLeft : MonoBehaviour
{
	private GameObject player;

	// Use this for initialization
	void Start ()
	{

		player = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Horizontal")>0||player.GetComponent<Rigidbody2D>().velocity.x>0)
		{
			this.GetComponent<LedgeGrab>().isActive= false;
		}
		else
		{
			this.GetComponent<LedgeGrab>().isActive = true;
		}	
	}
}
