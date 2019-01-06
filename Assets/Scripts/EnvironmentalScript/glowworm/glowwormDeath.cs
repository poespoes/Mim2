using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Examples
{
	public class glowwormDeath : MonoBehaviour
	{

		public GameObject childOne;
		public GameObject childTwo;
		public GameObject player;
		public CinemachineVirtualCamera cvcam;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		void killFirstChild()
		{
			Destroy(childOne);
			cvcam.m_Follow = player.transform;
		}

		void killSecondChild()
		{
			Destroy(childTwo);
			cvcam.m_Follow = player.transform;
		}
	}
}