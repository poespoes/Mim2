using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Examples
{
	public class CameraControl : MonoBehaviour
	{
		public CinemachineVirtualCamera focusedCamera;
		public int mainPriority;

		public CinemachineVirtualCamera previousCamera;

		// Use this for initialization
		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{
			mainPriority = focusedCamera.m_Priority;
		}

		public void FocusCamera(CinemachineVirtualCamera cameraToFocus)
		{
			previousCamera = focusedCamera;

			cameraToFocus.m_Priority = mainPriority + 1;
			mainPriority = mainPriority + 1;

			focusedCamera = cameraToFocus;
		}

		public void ReturnToPrevCamera()
		{
			previousCamera.m_Priority = mainPriority + 1;
			mainPriority = mainPriority + 1;
			focusedCamera = previousCamera;
		}

	}
}