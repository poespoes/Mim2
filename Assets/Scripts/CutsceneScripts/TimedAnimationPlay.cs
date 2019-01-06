using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAnimationPlay : MonoBehaviour
{

	public Animator animPlayer;
	public AnimationClip animClip;
	public float timer;

	public int animClipArraySize;
	public AnimationClip[] animClipArray;

	public string boolName;
	public bool callItself;
	public bool runOnCollision;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame



	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("PlayerEnteredScene");
			
			if (runOnCollision == true)
			{
				Initiate();
			}
		}
	}

	void Update () {
		if (callItself == true)
		{
			Initiate();
			callItself = false;
		}
	}

	public void Initiate()
	{
		Invoke("PlayAfterTime",timer);
	}

	public void PlayAfterTime()
	{
		animPlayer.Play(animClip.name);
		animPlayer.SetBool(boolName,true);
	}
}
