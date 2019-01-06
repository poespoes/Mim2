using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enviromentalDeath : MonoBehaviour
{

	public GameObject player;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
            Debug.Log("touched Deathbox");
			player = collision.gameObject;
			//Die();
			collision.GetComponent<Player>().Die();


		}
	}
	
	
	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


	public void Die()
	{
		GameObject blackout = GameObject.Find("BlackoutPanel");
		blackout.GetComponent<Image>().CrossFadeAlpha(255,5.0f,false);
		GameObject gameManager = GameObject.Find("GameManager");
		gameManager.GetComponent<gameState>().interactive = false;
		player.GetComponent<SpriteRenderer>().enabled = false;
		Invoke("Restart",2);
		
	
	}

}
