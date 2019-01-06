using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

	public CheckPointManager _CheckPointManager;

	// Use this for initialization
	void Start ()
	{
		_CheckPointManager = GameObject.Find("GameManager").GetComponent<CheckPointManager>();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			_CheckPointManager.lastCheckPoint = new Vector2(this.transform.position.x,this.transform.position.y);
			
		}
		
	}
}
