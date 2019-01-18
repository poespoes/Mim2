using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineChase : MonoBehaviour
{
	public float currentDistance;
	public float maxDistance;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentDistance < maxDistance)
		{
			Chase();
		}
		
	}

	void Chase()
	{
		if (PlayerStats.mimLit == true)
		{
			//chaseSequence.Append(this.transform.DOMoveX(PlayerStats.playerTransform.position.x, chaseTime, false));
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, PlayerStats.playerTransform.position, step);


		}
		else
		{
			this.transform.position = this.transform.position;
			

			//chaseSequence.Kill();
		}
	}
}
