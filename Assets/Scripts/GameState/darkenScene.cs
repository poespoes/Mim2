using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class darkenScene : MonoBehaviour
{
	public Player player;
	private bool isLit;
	public float tweenTime;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		isLit = player.isLIt;
		SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();

		if (isLit == false)
		{


			for (int i = 0; i < sprites.Length; i++)
			{
				//sprites[i].color = Color.black;
				sprites[i].DOColor(Color.black, tweenTime);
			}
		}
		else
		{
			for (int i = 0; i < sprites.Length; i++)
			{
				//sprites[i].color = Color.white;
				sprites[i].DOColor(Color.white, tweenTime);
			}
		}
	}
}
