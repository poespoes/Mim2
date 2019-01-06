using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightTransform : MonoBehaviour
{

	public NewLight newLight;
	

	// Use this for initialization
	void Start ()
	{

		if (newLight == null)
		{
			newLight = GameObject.Find("MimLight").GetComponent<NewLight>();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TransformStart()
	{
		newLight.isTransforming = true;
	}

	public void IsNotTransforming()
	{
		newLight.isTransforming = false;
	}
}
