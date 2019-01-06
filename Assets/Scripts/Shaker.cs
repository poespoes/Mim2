using System.Collections;
using System.Collections.Generic;
using Cinemachine.Examples;
using UnityEngine;

public class Shaker : MonoBehaviour
{

	public float amplitude;
	public float frequency;

	public CinemachineCameraShake _camerShake;

	// Use this for initialization
	void Start ()
	{
		_camerShake = GameObject.Find("GameManager").GetComponent<CinemachineCameraShake>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			_camerShake.amplitudeGain = amplitude;
			_camerShake.frequencyGain = frequency;
			_camerShake.Shake();
			
			Debug.Log("Camera is shaking");
			
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			_camerShake.UnShake();
			
		}
	}
}
