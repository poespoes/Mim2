using System.Collections;
using System.Collections.Generic;
using Cinemachine.Examples;
using UnityEngine;

namespace Cinemachine.Examples
{
	public class CutsceneTrigger : MonoBehaviour
	{

		
		public CutsceneManager cutsceneManager;

		public CinemachineVirtualCamera vCam;


		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player")
			{
				Debug.Log("Cutscene started");
				cutsceneManager.camera = vCam;
				//cutsceneManager.StartCutscene();

			}
		}
	}
}