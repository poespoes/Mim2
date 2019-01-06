using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightDeath : MonoBehaviour
{
	public float timer;
	public float timeRemaining;

	public Image redOutPanel;
	
	
	
	public Color A = Color.magenta;
	public Color B = Color.blue;
	public float speed = 0.01f;
	public float lerpProgress = 0;
	
	// Use this for initialization
	void Start ()
	{
		timeRemaining = timer;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Color tempColor = redOutPanel.color;
		
		//timer = timer - Time.deltaTime;
		//Debug.Log(timer + " seconds remaining");

		if (this.GetComponent<BeamController>().isOn == true)
		{
			timeRemaining = timeRemaining - Time.deltaTime;
			
			//tempColor.a -= Time.deltaTime / timeRemaining;
			
			redOutPanel.CrossFadeAlpha(155,10.0f,false);
		}
		else
		{
			if (timeRemaining < timer)
			{
				timeRemaining = timeRemaining + Time.deltaTime;
				//tempColor.a += Time.deltaTime / timeRemaining;
				
				redOutPanel.CrossFadeAlpha(0.1f,10.0f,false);
			}
			//redOutPanel.CrossFadeAlpha(0,timer,false);
		}


		
		//tempColor.a += Time.deltaTime / timer;

	
		redOutPanel.color = tempColor;



		//Debug.Log(timeRemaining + " seconds remaining" );


	}
}