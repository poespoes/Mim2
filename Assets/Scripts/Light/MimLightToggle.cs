using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimLightToggle : MonoBehaviour
{
	public float lightTimer;
	
	// Use this for initialization
	void Start ()
	{
		PlayerStats.canToggle = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerStats.isInteractive == true && PlayerStats.canToggle==true)
		{


			if (Input.GetButton("Fire1")) //the button you press to toggle light
			{
				MimLightOff();
			}
			else
			{
				MimLightOn();
			}
		}
	}


	public void MimLightOn()
	{
		PlayerStats.mimLit = true;
		if (PlayerStats.lightlessTimer < PlayerStats.originalLightlessTimer)
		{
			PlayerStats.lightlessTimer += Time.deltaTime;
		}
		

	}

	public void MimLightOff()
	{
		PlayerStats.mimLit = false;
		if (PlayerStats.lightlessTimer > 0)
		{
			PlayerStats.lightlessTimer -= Time.deltaTime;
		}
		
		
	}
	
}
