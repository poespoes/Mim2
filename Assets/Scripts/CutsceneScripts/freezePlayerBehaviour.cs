using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezePlayerBehaviour : MonoBehaviour
{

	public float holdtimer;
	public bool canFreeze;
	
	// Use this for initialization
	void Start ()
	{
		canFreeze = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		
			if (other.gameObject.CompareTag("Player"))
			{
				Debug.Log("Player Frozen");
				Freeze(other.gameObject);
			}

	
	}

	void Freeze(GameObject other)
	{
		GameObject.Find("GameManager").GetComponent<gameState>().interactive = false;
		other.GetComponent<PlayerAnimation>().WalkingState = 0;
		other.GetComponent<Player>().isWalking = false;
		other.GetComponent<Animator>().Play("Idle");
		Invoke("UnFreeze",holdtimer);
		
	}

	void UnFreeze()
	{
		GameObject.Find("GameManager").GetComponent<gameState>().interactive = true;
		Destroy(this.gameObject);
	}
}
