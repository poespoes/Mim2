using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineChase : MonoBehaviour
{
	public float currentDistance;
	public float maxDistance;
	public float speed;
	public bool isTriggered;
	public Transform target;
	public bool lighObjectFound;
	public Transform distraction; 

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isTriggered==true)
		{
			Chase();
		}
	
		
	}

	void Chase()
	{
		currentDistance = Vector2.Distance(PlayerStats.playerTransform.position, this.transform.position);
		if (lighObjectFound == false)
		{
			if (target.gameObject.tag==("Player") && PlayerStats.mimLit == true)
			{
				//chaseSequence.Append(this.transform.DOMoveX(PlayerStats.playerTransform.position.x, chaseTime, false));
				float step = speed * Time.deltaTime;
				transform.position = Vector2.MoveTowards(transform.position, target.position, step);
				speed += Time.deltaTime;


			}
		}
		
		else if(lighObjectFound==true)
		{
			//chaseSequence.Kill();
			if (distraction.GetComponent<GlowingLight>().objectLit==true)
			{
				Debug.Log("Chasing distraction");
				target = distraction;
				float step = speed * Time.deltaTime;
				transform.position = Vector2.MoveTowards(transform.position, target.position, step);
				speed += Time.deltaTime;
			}
			
		}
		else
		{
			this.transform.position = this.transform.position;
		}
	}
}
