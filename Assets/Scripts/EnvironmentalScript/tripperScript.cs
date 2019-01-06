using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Examples
{
	public class tripperScript : MonoBehaviour
	{
		public GameObject camera;
		public CinemachineBrain cameraBrain;

		// Use this for initialization
		void Start()
		{
			camera = GameObject.Find("Main Camera");
			cameraBrain = camera.GetComponent<CinemachineBrain>();
		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.tag == "Player")
			{
				Debug.Log("tripping");
				
				GameObject.Find("MimLight").GetComponent<SpriteRenderer>().enabled =
					!GameObject.Find("MimLight").GetComponent<SpriteRenderer>().enabled;

				GameObject trip = this.gameObject;
				GameObject player = GameObject.Find("Player");

				trip.GetComponent<Animate>().tripping = true;
				//Destroy(gameObject);
				player.transform.position = new Vector2(136.9f, -13.06f);
				player.gameObject.SetActive(false);



				player.GetComponent<Player>().canWalk = false;
				player.GetComponent<Player>().isWalking = false;
				player.GetComponent<Player>().moveSpeed = 0;

				cameraBrain.m_DefaultBlend.m_Time = 0f;
			}
		}
	}
}