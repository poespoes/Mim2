using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OIMonster : MonoBehaviour
{

	public float currentDistance;
	public float maxDistance;
	private Sequence chaseSequence;
	private float chaseTime;
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
		else
		{
			Die();
		}
		
		DisappearToggle();
	}

	void Chase()
	{
		
		currentDistance = Vector2.Distance(PlayerStats.playerTransform.position, this.transform.position);
		if (PlayerStats.mimLit == false)
		{
			//chaseSequence.Append(this.transform.DOMoveX(PlayerStats.playerTransform.position.x, chaseTime, false));
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, PlayerStats.playerTransform.position, step);
			speed += 2*Time.deltaTime;



		}
		else
		{
			this.transform.position = this.transform.position;
			

			//chaseSequence.Kill();
		}
		
	}

	public void Die()
	{
		Destroy(this.gameObject);
	}

	void DisappearToggle()
	{
		this.GetComponentInChildren<SpriteRenderer>().enabled = !PlayerStats.mimLit;
		this.GetComponent<Collider2D>().enabled = !PlayerStats.mimLit;
	}
}
