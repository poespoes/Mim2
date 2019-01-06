using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
	
	public Vector2 lastCheckPoint;

	private void Awake()
	{
		lastCheckPoint = GameObject.Find("Player").transform.position; 
		
	}
}
