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
	public bool unAfraid; //right now this does nothing

	public bool notAfraidOfOI;

	public float fearDecreaseFactor; //how fast she regains her courage in the light
	public float fearIncreaseFactor; //how fast she becomes afraid in the dark

    public float TimeUntilFear1; //Time out of LightlessTimer before she enters fear 1
    public float TimeUntilFear2; //Time out of LightlessTimer before she enters fear 2

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		scared = Physics2D.OverlapCircle(this.transform.position,scaredRadius,OILayer);
		
		veryScared = Physics2D.OverlapCircle(this.transform.position,veryscaredRadius,OILayer);
		
		unAfraid = Physics2D.OverlapCircle(this.transform.position,scaredRadius,OILayer);

		if (notAfraidOfOI == true)
		{
			FearCheck();
		}


			LightLessFear();
	
		
		
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
			if (PlayerStats.lightlessFear == false)
			{
				PlayerStats.fear = 0;
			}
		}
	}

	void LightLessFear() //controls how afraid or not afraid they are when the light is off
	{
		Debug.Log("Fear the darkness!!!");
		
		if (PlayerStats.lightlessTimer > (TimeUntilFear1 * PlayerStats.originalLightlessTimer))
		{
			PlayerStats.fear = 0;
			PlayerStats.lightlessFear = false;
		}
		else if (PlayerStats.lightlessTimer > (TimeUntilFear2 * PlayerStats.originalLightlessTimer))
		{
			PlayerStats.fear = 1;
			PlayerStats.lightlessFear = true;
		}
		else
		{
			PlayerStats.fear = 2;
			PlayerStats.lightlessFear = true;	
		}
	}

}
