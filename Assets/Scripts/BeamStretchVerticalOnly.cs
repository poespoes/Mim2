using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Examples
{
	public class BeamStretchVerticalOnly : MonoBehaviour
	{  
		public CinemachineVirtualCamera cineVCam;
		public GameObject lightBeam;
		public float lightFactor;
		float originalOrtho;

		// Use this for initialization
		void Start()
		{
			cineVCam = GameObject.Find("CM vcam7").GetComponent<CinemachineVirtualCamera>();
			lightBeam = this.transform.Find("MimLight").gameObject;
			//lightFactor = 200;
			originalOrtho = cineVCam.m_Lens.OrthographicSize;
		}

		// Update is called once per frame
		void Update()
		{
			Vector3 thisPos = this.transform.position;
            
			GameObject v_Mouse = GameObject.Find("VirtualMouse");


			float height = v_Mouse.transform.position.y - thisPos.y;
			
//			Debug.Log("The Height is "+ height);
			
			float distanceFactor = height / lightFactor;

			if (distanceFactor > 1)
			{
				distanceFactor = 1;
			}

			if (distanceFactor < -1)
			{
				distanceFactor = -1;
			}
			
			var cineComposer = cineVCam.GetCinemachineComponent<CinemachineFramingTransposer>();

			//cineComposer.m_ScreenY = cineComposer.m_ScreenY + distanceFactor;

			cineComposer.m_ScreenY = distanceFactor;
			
			

		}
	}
}