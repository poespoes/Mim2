using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Examples
{
	public class introScript : MonoBehaviour
	{
		public Animator handAnimator;
		public CinemachineVirtualCamera vcam;

		public GameObject vignette;
		public GameObject mimShadow;
		
		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.tag == "MimLight")
			{
				handAnimator.SetBool("willShake", true);
				Debug.Log("Shaken not stirred");

				SpriteRenderer vine = GameObject.Find("7_vine").GetComponent<SpriteRenderer>();
				vine.sortingOrder = 25;

				vcam.Priority = 25;
				
				vignette.SetActive(false);
				mimShadow.SetActive(false);

			}


		}
	}
}