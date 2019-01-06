using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Examples
{
	public class glowwormActivate : MonoBehaviour
	{

		public string animBool;
		public CinemachineVirtualCamera playerCam;


		// Use this for initialization
		void Start()
		{
			playerCam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.tag == "MimLight")
			{
				Debug.Log("Worms are lit");
				transform.parent.GetComponent<Animator>().SetBool(animBool,true);

				playerCam.m_LookAt = this.transform;
				playerCam.m_Follow = this.transform;
			}
		}

	
	}
}