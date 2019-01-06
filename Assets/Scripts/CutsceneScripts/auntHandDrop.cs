using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auntHandDrop : MonoBehaviour
{

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			player = other.gameObject;

			player.transform.parent = this.transform;
			
			this.GetComponent<Animator>().SetBool("isShaking",true);
		}
	}

	void UnParent()
	{
		player.transform.parent = null;
	}
}
