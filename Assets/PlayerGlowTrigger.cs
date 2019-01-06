using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlowTrigger : MonoBehaviour
{


	
	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.name == "PlayerGlow" || other.transform.tag == "worm")
		{
			this.GetComponent<SpriteRenderer>().enabled = true;
		}
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		
		if (other.transform.name == "PlayerGlow"|| other.transform.tag == "worm")
		{
			this.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
	
}
