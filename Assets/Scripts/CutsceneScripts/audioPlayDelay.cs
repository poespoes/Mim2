using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayDelay : MonoBehaviour
{

	public float delay;
	public bool hasExecuted;
	public AudioSource audio;

	// Use this for initialization
	void Start ()
	{
		hasExecuted = false;
		audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		
			if (other.CompareTag("Player"))
			{
				if (hasExecuted == false)
				{
					Invoke("musicPlay", delay);
					hasExecuted = true;
					
				}
			}

		
	}

	private void musicPlay()
	{
		//this.GetComponent<AudioSource>().Play();
		
		audio.Play();
	}
}
