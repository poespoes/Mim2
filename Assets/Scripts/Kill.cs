using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Kill : MonoBehaviour
{

	public bool lightDeath;
	public enum TypeOfDeath
	{
		OI,
		Vine,
		DeathOnTouch
	}

	public TypeOfDeath _typeOfDeath;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerStats.canDie = true;
			if (other.GetComponent<PlayerStats>() != null && PlayerStats.mimLit==true && _typeOfDeath==TypeOfDeath.Vine)
			{
				//Death(other.gameObject);

				
			}
			else if(other.GetComponent<PlayerStats>() != null && PlayerStats.mimLit==false && _typeOfDeath==TypeOfDeath.OI)
			{
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
		}
	}

	private void Death(GameObject other)
	{
		other.GetComponent<PlayerStats>().Die();
				
		float horizontalSpeed=0;
		DOTween.To(()=> horizontalSpeed, x=> horizontalSpeed = x, 0, 1);
			
		other.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalSpeed,other.GetComponent<Rigidbody2D>().velocity.y);
	}
}
