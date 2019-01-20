using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimLightToggle : MonoBehaviour
{ 
	
	// Use this for initialization
	void Start ()
	{


	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerStats.isInteractive == true)
		{


			if (Input.GetButton("Fire1"))
			{
				MimLightOn();
			}
			else
			{
				MimLightOff();
			}
		}
	}


	public void MimLightOn()
	{
		PlayerStats.mimLit = true;
	}

	public void MimLightOff()
	{
		PlayerStats.mimLit = false;
	}
}
