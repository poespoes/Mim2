using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Examples
{
	public class CutsceneManager : MonoBehaviour
	{
		private GameObject player;
		private GameObject mimLeaf;

		public CinemachineVirtualCamera camera;
		public CinemachineVirtualCamera oldCamera;
		public int priority;
		public CameraControl cameraControl;
		
		public GameObject mainCamera;
		public CinemachineBrain cameraBrain;

		private int newPriority;

		// Use this for initialization
		void Start()
		{
			player = GameObject.Find("Player");
			mimLeaf = GameObject.Find("MimLeaf");
			
			
			cameraControl = GameObject.Find("GameManager").GetComponent<CameraControl>();
			//priority = camera.m_Priority;

			
			
			mainCamera = GameObject.Find("Main Camera");
			cameraBrain = mainCamera.GetComponent<CinemachineBrain>();

			oldCamera = cameraControl.focusedCamera;
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void StartCutscene()
		{
			GameObject.Find("GameManager").GetComponent<gameState>().interactive = false;
			player.GetComponent<PlayerAnimation>().WalkingState = 0;
			player.GetComponent<Player>().isWalking = false;
			player.GetComponent<Animator>().Play("Idle");
			player.GetComponent<SpriteRenderer>().enabled = false;
			player.transform.Find("MimHL").GetComponent<SpriteRenderer>().enabled = false;
			mimLeaf.GetComponentInChildren<SpriteRenderer>().enabled = false;

			if (camera != null)
			{
				FocusCamera();
			}



		}

		public void EndCutScene()
		{
			GameObject.Find("GameManager").GetComponent<gameState>().interactive = true;
			player.GetComponent<SpriteRenderer>().enabled = true;
			mimLeaf.GetComponentInChildren<SpriteRenderer>().enabled = true;
			player.transform.Find("MimHL").GetComponent<SpriteRenderer>().enabled = true;
			ReturnCamera();
		}

		void FocusCamera()
		{
			priority = cameraControl.mainPriority + 1;
			camera.m_Priority = priority;
			cameraControl.focusedCamera = camera;
			
		}

		void ReturnCamera()
		{
			priority = cameraControl.mainPriority + 1;
			oldCamera.m_Priority = priority;
			cameraControl.focusedCamera = oldCamera;
		}
	}
}
