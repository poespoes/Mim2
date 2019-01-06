using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneEnd : MonoBehaviour
{

	public Image blackOutCanvas;
	
	// Use this for initialization
	void Start ()
	{

		blackOutCanvas = GameObject.Find("BlackoutPanel").GetComponent<Image>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			NextScene();
		}
	}

	void NextScene()
	{

		blackOutCanvas.DOColor(Color.black, 2);
		Invoke("LoadNextScene",2);

	}


	void LoadNextScene()
	{
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		
	}
}
