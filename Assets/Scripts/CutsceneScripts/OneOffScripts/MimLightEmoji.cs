using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimLightEmoji : MonoBehaviour
{
	public Animator MimEmoji;

	// Use this for initialization
	void Start ()
	{
		MimEmoji = GameObject.Find("MimEmoji").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartEmojiHint()
	{
		Invoke("MimEmojiHint", 5);
	}

	void MimEmojiHint()
	{
		MimEmoji.SetBool("MimTurnOnLight",true);
	}
}
