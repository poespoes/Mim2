using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Kill : MonoBehaviour
{

	public bool lightDeath;
	public float deathTimer;
	public bool deathCounterStarted;
	private float origDeathTimer;
	public enum TypeOfDeath
	{
		OI,
		Vine,
		DeathOnTouch
	}

	public TypeOfDeath _typeOfDeath;

	// Use this for initialization
	void Start ()
	{
		if (deathTimer != null)
		{
			deathTimer = 0.5f;
		}

		origDeathTimer = deathTimer;

	}
	
	// Update is called once per frame
	void Update () {
		
		DelayedDeath();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			
			if (other.GetComponent<PlayerStats>() != null && PlayerStats.mimLit==true && _typeOfDeath==TypeOfDeath.Vine)
			{
				
				Debug.Log("Death started");
				//PlayerStats.canDie = true;
				deathCounterStarted = true;

				
				

				
			}
			else if(other.GetComponent<PlayerStats>() != null && PlayerStats.mimLit==false && _typeOfDeath==TypeOfDeath.OI)
			{
				Debug.Log("OI Death");
				PlayerStats.canDie = true;
				Death(other.gameObject);
			}
		}
		else if (other.GetComponent<GlowingLight>() != null)
		{
			other.GetComponent<GlowingLight>().LightOff();
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerStats.canDie = false;
			//deathTimer = origDeathTimer;
			deathCounterStarted = false;
		}
	}

	private void Death(GameObject other)
	{
		
		other.GetComponent<PlayerStats>().Die();
				
		float horizontalSpeed=0;
		DOTween.To(()=> horizontalSpeed, x=> horizontalSpeed = x, 0, 1);
			
		other.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalSpeed,other.GetComponent<Rigidbody2D>().velocity.y);
	}

	public void DelayedDeath()
	{
		if (deathCounterStarted == true)
		{
			deathTimer -= Time.deltaTime;
		}
		else
		{
			deathTimer = origDeathTimer;
		}
		
		if (deathTimer <= 0)
		{
			Debug.Log("Timed death");
			Death(PlayerStats.player);
		}
	}
}
