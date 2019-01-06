using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFollow : MonoBehaviour {
	
	public GameObject light ;

	// Use this for initialization
	void Start ()
	{
		light = GameObject.Find("MimLight");
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.position = light.transform.position;
		this.transform.rotation = light.transform.rotation;

		
	}
}
