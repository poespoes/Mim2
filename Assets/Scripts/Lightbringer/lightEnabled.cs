using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightEnabled : MonoBehaviour {
	public GameObject light ;

	// Use this for initialization
	void Start () {
		light = GameObject.Find("MimLight");
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.GetComponent<SpriteRenderer>().enabled = light.GetComponent<SpriteRenderer>().enabled;
	}
}
