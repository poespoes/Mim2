using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightComponent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		LightToggleSprite();
	}

	public void LightToggleSprite()
	{
		//this.GetComponent<SpriteRenderer>().enabled = PlayerStats.mimLit;

		SpriteRenderer[] _spriteRenderer = this.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer _sprite in _spriteRenderer )
		{
			//_sprite.enabled = PlayerStats.mimLit;
		}
	}
}
