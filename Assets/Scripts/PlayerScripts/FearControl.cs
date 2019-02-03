using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearControl : MonoBehaviour
{
	public LayerMask OILayer;

	public bool scared;
	public bool veryScared;

	public float scaredRadius;
	public float veryscaredRadius;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		scared = Physics2D.OverlapCircle(this.transform.position,scaredRadius,OILayer);
		
		veryScared = Physics2D.OverlapCircle(this.transform.position,veryscaredRadius,OILayer);
		
		FearCheck();
	}

	void FearCheck()
	{
		if (veryScared == true)
		{
			PlayerStats.fear = 2;
		}
		else if (scared==true)
		{
			PlayerStats.fear = 1;
		}
		else
		{
			PlayerStats.fear = 0;
		}
	}
}
