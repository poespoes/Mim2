using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Cinemachine.Examples
{
	public class Mantle : MonoBehaviour
	{

		//public CinemachineVirtualCamera vCam;
		public gameState GameState;
		public GameObject player;

		public Transform playerPos;

		public CameraControl cameraControl;

		public AnimationClip pullUpClip;

		public NewLedgeGrab NewLedge;

		// Use this for initialization
		void Start()
		{
			GameState = GameObject.Find("GameManager").GetComponent<gameState>();
			player = this.gameObject;
			cameraControl = GameObject.Find("GameManager").GetComponent<CameraControl>();

			//vCam = GameObject.Find("CM Vcam1").GetComponent<CinemachineVirtualCamera>();

			NewLedge = GameObject.Find("GrabHand").GetComponent<NewLedgeGrab>();
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void MantleStart(Transform target)
		{
			Debug.Log("PullingUp");
			
			
			player.GetComponent<Animator>().Play("MimLedgeGrabUp");
			
		
			
			//vCam.m_Follow = target;

			playerPos = target;

			player.transform.DOMove(playerPos.position, pullUpClip.length);

			//cameraControl.FocusCamera(vCam);

			//vCam.transform.DOMove(new Vector3(transform.position.x,transform.position.y,vCam.transform.position.z),0.25f) ;
		}

		public void MantleUp()
		{
			GameState.interactive = true;
			//vCam.m_Follow = this.transform;
			
			//cameraControl.ReturnToPrevCamera();
			
			player.GetComponent<Animator>().SetBool("MimLedgeGrab",false);
			player.GetComponent<PlayerAnimation>().WalkingState = 0;
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

			NewLedge.canGrab = false;
			NewLedge.ledge = null;
			NewLedge.isGrabbing = false;

			//player.transform.position = playerPos.position;
		}
	}
}