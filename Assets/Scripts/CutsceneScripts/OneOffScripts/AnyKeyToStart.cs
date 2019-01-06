using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyKeyToStart : MonoBehaviour
{
	public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey)
		{
			this.GetComponent<Animator>().SetBool("Start",true);
			
		}
	}
}
