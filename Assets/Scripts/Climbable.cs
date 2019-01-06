using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.transform.tag == "Player")
		{
			other.GetComponent<Player>().canClimb = true;
			
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform.tag == "Player")
		{
			other.GetComponent<Player>().canClimb = false;

		}
	}
}
