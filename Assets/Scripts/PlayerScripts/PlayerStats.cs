using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

	
	public Animator playerAnim;

	public static int fear;
	public static bool mimLit; //if mim is lit or not
	public static bool canDie; //if can die is true and the light is activated, the vine kills Mim
	public static Transform playerTransform;
	public static GameObject player;
	public static bool isInteractive;


	private void Awake()
	{
		isInteractive = true;
		playerTransform = this.transform;
		player = this.transform.gameObject;
	}
	// Use this for initialization
	
	void Start ()
	{
		playerAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		FearChange();
		IncreaseFear();
		playerTransform = this.transform;

		if (canDie == true && mimLit == true)
		{
			Die();
		}
	}


	public void FearChange()
	{
		if (fear == 0)
		{
			playerAnim.SetLayerWeight(0,1);
			playerAnim.SetLayerWeight(1,0);
			playerAnim.SetLayerWeight(2,0);
		}
		else if (fear == 1)
		{
			playerAnim.SetLayerWeight(0,0);
			playerAnim.SetLayerWeight(1,1);
			playerAnim.SetLayerWeight(2,0);
		}
		else if (fear == 2)
		{
			playerAnim.SetLayerWeight(0,0);
			playerAnim.SetLayerWeight(1,0);
			playerAnim.SetLayerWeight(2,1);
		}
		else
		{
			fear = 0;
		}
	}

	public void IncreaseFear()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			fear++;
		}
	}

	public void Die()
	{
		PlayerStats.isInteractive = false;
		PlayerStats.canDie = false;
		
		Component[] sprites;

		sprites = player.GetComponentsInChildren<SpriteRenderer>();

		foreach (SpriteRenderer renderer in sprites)
		{
			renderer.enabled = false;
		}

		
		
		Invoke("RestartScene",2);
		
	}

	public void RestartScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
