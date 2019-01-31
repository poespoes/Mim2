using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Kill : MonoBehaviour
{

	public bool lightDeath;

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
			if (other.GetComponent<PlayerStats>() != null && PlayerStats.mimLit==true)
			{
				other.GetComponent<PlayerStats>().Die();
				
				float horizontalSpeed=0;
				DOTween.To(()=> horizontalSpeed, x=> horizontalSpeed = x, 0, 1);
			
				other.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalSpeed,other.GetComponent<Rigidbody2D>().velocity.y);
			}
		}
	}
}
