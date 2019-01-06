using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VineKillLight : MonoBehaviour
{
	public bool canDie;
	public GameObject player;

	public bool isAttacking;

	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Player>().isLIt == true && canDie == true && player.GetComponent<Player>().invulnerable==false)
		{
			player.GetComponent<Player>().Die();
			//Die();
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			canDie = true;
			Debug.Log("Player can Die");
		}
		
		this.GetComponent<Animator>().SetBool("isAttacking",false);
		this.GetComponent<Animator>().Play("Idle");
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			canDie = false;
		}
	}

	public void Die()
	{
		GameObject blackout = GameObject.Find("BlackoutPanel");
		blackout.GetComponent<Image>().CrossFadeAlpha(255,5.0f,false);
		GameObject gameManager = GameObject.Find("GameManager");
		gameManager.GetComponent<gameState>().interactive = false;
		Invoke("Restart",2);
		
	
	}
	
	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void VineRetract()
	{
		this.GetComponent<Animator>().SetBool("isAttacking",false);
		this.GetComponent<Animator>().Play("Entry");
	}
}
