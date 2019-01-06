using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVineTrigger : MonoBehaviour
{
	public VineChaseLight parentVine;

	// Use this for initialization
	void Start ()
	{
		parentVine = this.transform.parent.GetComponent<VineChaseLight>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			parentVine.inRange = true;
		}
		
	
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			parentVine.inRange = false;
		}
	}
}
