using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class handDropSceneChange : MonoBehaviour
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

	void blackOut()
	{
		blackOutCanvas.CrossFadeAlpha(255,5,false);
		Invoke("NextScene",4);
	}

	void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}
}
