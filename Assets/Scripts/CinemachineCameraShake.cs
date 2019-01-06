using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Examples
{
	public class CinemachineCameraShake : MonoBehaviour
	{

		public GameObject _gameManager;
		public CameraControl _cameraControl;
		public CinemachineVirtualCamera _virtualCamera;

		public float amplitudeGain;
		public float frequencyGain;
		

		// Use this for initialization
		void Start()
		{
			_gameManager  = GameObject.Find("GameManager");
			_cameraControl = _gameManager.GetComponent<CameraControl>();
			
		}

		// Update is called once per frame
		void Update()
		{
			_virtualCamera = _cameraControl.focusedCamera;

			if (Input.GetKey(KeyCode.F))
			{
				Shake();
			}
			else
			{
				UnShake();
			}

		}

		public void Shake()
		{
			_virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitudeGain;
			_virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequencyGain;
		}
		
		public void UnShake()
		{
			_virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
			_virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
		}
	}
}