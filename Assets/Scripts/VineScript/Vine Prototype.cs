using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinePrototype : MonoBehaviour {

	public Animator vineAnimator;
	
	// Use this for initialization
	void Start ()
	{

		vineAnimator = this.GetComponent<Animator>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "MimLight")
		{
			Debug.Log("END SCENE");
			vineAnimator.SetBool("isAttacking", true);	
			
		}
	}
	
}
