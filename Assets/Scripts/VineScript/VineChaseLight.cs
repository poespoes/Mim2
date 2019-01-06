using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class VineChaseLight : MonoBehaviour
{
	public bool inRange;
	public bool isLit;
	public bool noLeaf;
	public bool interactive;

	public float time;

	public Transform destination;
	public Vector3 originalPos;

	public GameObject player;
	

	// Use this for initialization
	void Start () {
		if (time == 0)
		{
			time = 5;
		}

		originalPos = this.transform.position;
		
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		interactive = GameObject.Find("GameManager").GetComponent<gameState>().interactive;
		
		noLeaf = GameObject.Find("Player").GetComponent<Player>().noLeaf;
		
		isLit = GameObject.Find("Player").GetComponent<Player>().isLIt;

		if (player.GetComponent<Player>().isDying == true)
		{
			
			Debug.Log("Vine is going back");
			ResetVine();
			
		} else if (inRange == true && isLit == true && noLeaf == false && interactive==true) 
		{
			this.transform.DOMove(destination.transform.position, time);
			Debug.Log("Vine is chasing");
		}
		
		
	}

	void ResetVine()
	{
		inRange = false;
		isLit = false;

		this.transform.DOKill(this.transform.gameObject);

		this.transform.DOMove(originalPos, 1);
		this.transform.position = originalPos;
	}
}
