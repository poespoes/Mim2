using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineTriggeredByLight : MonoBehaviour {
	public float animationSpeed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			if (other.GetComponent<Player>().isLIt == true)
			{
				Debug.Log("VineTriggered");
				this.transform.parent.GetComponent<Animator>().SetBool("isAttacking", true);
				this.transform.parent.GetComponent<Animator>().speed = animationSpeed;
			}

		}
	}
}
