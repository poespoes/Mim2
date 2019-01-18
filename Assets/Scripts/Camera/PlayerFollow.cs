using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

	public Transform playerTransform;

	
	[SerializeField]private float stopDistance;

	[SerializeField]private float maxDistance;

	public float followTime;
	
	
	// Use this for initialization
	void Start ()
	{

		playerTransform = GameObject.FindWithTag("Player").transform;

		
	
		stopDistance = 0.25f;
		maxDistance = 0.5f;

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	private void FixedUpdate()
	{
		
	}
}
