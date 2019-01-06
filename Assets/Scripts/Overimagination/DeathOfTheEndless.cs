using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOfTheEndless : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag=="monster")
		{
			Destroy(other.transform.parent.gameObject);
			Debug.Log("Destroy Monster");
		}
	}
}
