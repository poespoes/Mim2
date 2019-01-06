using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICrossFade : MonoBehaviour
{
	public GameObject canvas;
	public bool willFadeIn;
	public bool willFadeOut;
	
	// Use this for initialization
	void Start ()
	{
		
		
		willFadeIn = false;
		willFadeOut = false;
		
		canvas = this.gameObject;
		canvas.GetComponent<Image>().color = Color.black;
		
		canvas.GetComponent<Image>().CrossFadeAlpha(0.1f,6.0f,false);
		
		//canvas.GetComponent<Image>().CrossFadeAlpha(255,10.0f,false);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (willFadeIn == true)
		{
			fadeIn();
			
		}
		
		if (willFadeOut == true)
		{
			fadeIn();
			
		}
	}

	void fadeIn()
	{
		canvas.GetComponent<Image>().CrossFadeAlpha(0,2.0f,false);
		//willFadeIn = false;
	}

	void fadeOut()
	{
		canvas.GetComponent<Image>().CrossFadeAlpha(255,2,false);
		Debug.Log("BlackoutReceived");
		//willFadeOut = false;
	}
}
