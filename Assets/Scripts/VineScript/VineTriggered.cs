using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineTriggered : MonoBehaviour
{

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
			this.transform.parent.GetComponent<Animator>().SetBool("isAttacking",true);
			this.transform.parent.GetComponent<Animator>().speed = animationSpeed;
			
		}
	}
}
