using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanity : MonoBehaviour
{

	public float sanity;
	public float maxSanity;
	
	public Player playerComp;
	public PlayerAnimation playerAnim;

	// Use this for initialization
	void Start ()
	{
		playerComp = this.GetComponent<Player>();
		playerAnim = this.GetComponent<PlayerAnimation>();
		if (sanity == null)
		{
			sanity = 10;
		}
		maxSanity = sanity;
	}
	
	// Update is called once per frame
	void Update ()
	{
		sanity = Mathf.Clamp(sanity, 0, maxSanity);

		if (playerComp.isLIt == false)
		{
			sanity -= Time.deltaTime;
			sanity = Mathf.Clamp(sanity, 0, maxSanity);
			
		}
		else
		{
			sanity += Time.deltaTime;
			sanity = Mathf.Clamp(sanity, 0, maxSanity);
		}

		walkingStateSanity();
		
	}

	void walkingStateSanity()
	{
		if (playerComp.isLIt == false)
		{
			if (sanity > (0.99f * maxSanity))
			{
				
			}
			if (sanity > (0.6f * maxSanity))
			{
				playerAnim.WalkingState = 5;
			}
			else if (sanity > (0.3f) * maxSanity && playerComp.isWalking == true)
			{
				playerAnim.WalkingState = 2;
			}
			else if (sanity > 0 && playerComp.isWalking == true)
			{
				playerAnim.WalkingState = 3;
			}
			else if (sanity <= 0)
			{
				sanity = 0;
				playerComp.Die();
			}
		}
		else
		{
			sanity = maxSanity;
		}
	}
}


