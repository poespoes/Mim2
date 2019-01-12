using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

	
	public Animator playerAnim;

	public int fear;

	// Use this for initialization
	void Start ()
	{
		playerAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		FearChange();
		IncreaseFear();
	}


	public void FearChange()
	{
		if (fear == 0)
		{
			playerAnim.SetLayerWeight(0,1);
			playerAnim.SetLayerWeight(1,0);
			playerAnim.SetLayerWeight(2,0);
		}
		else if (fear == 1)
		{
			playerAnim.SetLayerWeight(0,0);
			playerAnim.SetLayerWeight(1,1);
			playerAnim.SetLayerWeight(2,0);
		}
		else if (fear == 2)
		{
			playerAnim.SetLayerWeight(0,0);
			playerAnim.SetLayerWeight(1,0);
			playerAnim.SetLayerWeight(2,1);
		}
		else
		{
			fear = 0;
		}
	}

	public void IncreaseFear()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			fear++;
		}
	}
}
