using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cinemachine.Examples
{
	public class letThereBeLight : MonoBehaviour
	{
		public CinemachineVirtualCamera cineVCam;
		public GameObject blackout;
		public bool canActivate;
		public bool hasActivated;
		public GameObject player;


		// Use this for initialization
		void Start()
		{
			
			//cineVCam = GameObject.Find("CM vcam7").GetComponent<CinemachineVirtualCamera>();

			blackout = GameObject.Find("BlackoutPanel");

			canActivate = false;
			hasActivated = false;

			player = GameObject.Find("Player");

		}

		// Update is called once per frame
		void Update()
		{
			if (canActivate == true & hasActivated == false)
			{
				if (Input.GetMouseButtonDown(1))
				{
					Debug.Log("LET THERE BE LIGHT");
					blackout.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.1f, false);
					hasActivated = true;

					cineVCam.Follow = player.transform;
					
					GameObject v_cam = GameObject.Find("VirtualCamera");
					//v_cam.transform.position = GameObject.Find("PodScale").transform.position;
					
					GameObject.Find("GameManager").GetComponent<gameState>().interactive = true;
					
					
				}
			}
		}
	}
}
