using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Examples
{
	public class glowWormScript : MonoBehaviour
	{

		public CinemachineVirtualCamera playerCam;
		public GameObject player;
		public gameState gameManager;

		// Use this for initialization
		void Start()
		{
			playerCam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
			player = GameObject.Find("Player");
			gameManager = GameObject.Find("GameManager").GetComponent<gameState>();
		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.transform.tag == "MimLight")
			{
				playerCam.m_LookAt = this.transform;
				playerCam.m_Follow = this.transform;

				this.GetComponent<Animator>().SetBool("hasTriggered", true);
				gameManager.interactive = false;

				playerCam.m_Lens.OrthographicSize = playerCam.m_Lens.OrthographicSize + 2;
				//player.GetComponent<BeamStretch>().originalOrtho = playerCam.m_Lens.OrthographicSize;
				player.GetComponent<BeamStretch>().minStretch = playerCam.m_Lens.OrthographicSize;
				player.GetComponent<BeamStretch>().maxStretch = playerCam.m_Lens.OrthographicSize+ + 5;
			}
		}

		public void endMe()
		{
			playerCam.m_LookAt = player.transform;
			playerCam.m_Follow = player.transform;
			Destroy(this.gameObject);
			gameManager.interactive = true;
		}
	}
}