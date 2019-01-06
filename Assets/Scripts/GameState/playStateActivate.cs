using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class playStateActivate : MonoBehaviour {
	
	public PlayableDirector director;
	public gameState gameState;

	// Use this for initialization
	void Start ()
	{
		gameState = GameObject.Find("GameManager").GetComponent<gameState>();
		director = this.GetComponent<PlayableDirector>();
		gameState.interactive = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log("This clip is " + director.state);

		String playableState = director.state.ToString();

		if (playableState == "Paused")
		{
			
			gameState.interactive = true;
		}

	}
}
