using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{

	public Transform grabPos;
	public Transform getUpPos;
	
	// Use this for initialization
	void Start ()
	{
		grabPos = this.transform.GetChild(0).transform;
		getUpPos = this.transform.GetChild(1).transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
