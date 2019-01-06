using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset()
	{
		VineKillLight[] anim = GetComponentsInChildren<VineKillLight>();
		for (int i = 0; i < anim.Length; i++)
		{
			anim[i].VineRetract();
		}
	}
}
