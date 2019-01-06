using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadScene()
	{
		//SceneManager.LoadScene(nextScene.name);

		int i = SceneManager.GetActiveScene().buildIndex + 1;
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
