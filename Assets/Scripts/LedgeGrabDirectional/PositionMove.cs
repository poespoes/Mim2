using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMove : MonoBehaviour
{

	public Transform left;
	public Transform right;
	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").gameObject;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<NewLedgeGrab>().isGrabbing == false)
		{
			if (Input.GetAxisRaw("Horizontal") < 0 || player.GetComponent<Rigidbody2D>().velocity.x < 0)
			{
				this.transform.position = left.transform.position;
			}

			if (Input.GetAxisRaw("Horizontal") > 0 || player.GetComponent<Rigidbody2D>().velocity.x > 0)
			{
				this.transform.position = right.transform.position;
			}
		}
	}
}
