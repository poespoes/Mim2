using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetThereBeLeaf : MonoBehaviour {

	// Use this for initialization
	public void Leafeon()
	{
		GameObject.Find("Player").GetComponent<Player>().noLeaf = false;
	}
}
