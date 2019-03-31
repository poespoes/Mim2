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


	public void MimLightOn() //Lightless timer goes down here
	{
		PlayerStats.mimLit = true;
		if (PlayerStats.lightlessTimer < PlayerStats.originalLightlessTimer)
		{
			PlayerStats.lightlessTimer += Time.deltaTime;
		}
		

	}

	public void MimLightOff() //This also triggers the lightless fear
	{
		PlayerStats.mimLit = false;
		if (PlayerStats.lightlessTimer > 0 && this.GetComponent<DarkLOSystem>()==null) //hopefully prevents her from being afraid in the dark when she has dark LO attached
		{
			PlayerStats.lightlessTimer -= Time.deltaTime;
		}
		
		
	}
	
}
