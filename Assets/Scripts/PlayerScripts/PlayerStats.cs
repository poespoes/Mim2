using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

	
	public Animator playerAnim;

	public static int fear;
	public int Fear;
	public static bool mimLit; //if mim is lit or not
	public bool _mimLit;
	public static bool vineCanChase;
	public bool _vineCanChase;
	public static bool canToggle; //whether or not the light is ready to toggle or not - true when animation ends
	public bool CanToggle;
	public static bool canDie; //if can die is true and the light is activated, the vine kills Mim
	public bool CanDie;
	public static Transform playerTransform;
	public static GameObject player;
	public static bool isInteractive;
	public bool _isInteractive;
	public static float moveSpeed;
    public float fear1multiplier;
    public float fear2multiplier;

	public static float lightlessTimer;
	public static bool lightlessFear;
	public float _lightLessTimer;
	public static float originalLightlessTimer;


	public static float originalGravityScale;
	public static float originalLinearDrag;
	public static float originalAngularDrag;

	public static bool grounded;

	public static bool startsSleeping;
	public bool _startsSleeping;

    public static bool leafDead;

    private void Awake()
	{
		isInteractive = true;
		playerTransform = this.transform;
		player = this.transform.gameObject;
		lightlessTimer = _lightLessTimer;
		originalLightlessTimer = _lightLessTimer;
		originalGravityScale = player.GetComponent<Rigidbody2D>().gravityScale;
		originalAngularDrag = player.GetComponent<Rigidbody2D>().angularDrag;
		originalLinearDrag = player.GetComponent<Rigidbody2D>().drag;
		startsSleeping = _startsSleeping;


	}
	// Use this for initialization
	
	void Start ()
	{
		playerAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
		moveSpeed = PlayerMovement.originalMoveSpeed;
		leafDead = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		_isInteractive = isInteractive;
		_mimLit = mimLit;

		CanDie = canDie;
		
		FearChange();
		NoLight();
		IncreaseFear();
        //BurstSpeed();

        playerTransform = this.transform;

		if (canDie == true && mimLit == true)
		{
			Die();
		}

		Fear = fear;
		_lightLessTimer = lightlessTimer;

		CanToggle = canToggle;

		//kills player if they're too afraid - might consider removing
        if(lightlessTimer <= 0) {
            //Die();
        }

		//tempTest

		if (Input.GetKeyDown(KeyCode.M))
		{
			isInteractive = !isInteractive;
		}

		grounded = player.GetComponent<PlayerMovement>().grounded;
		_vineCanChase = vineCanChase;
	}


	public void FearChange() //Changes the animator's layer weight based on current fear level
	{
		if (fear == 0)
		{
			playerAnim.SetLayerWeight(0,1);
			playerAnim.SetLayerWeight(1,0);
			playerAnim.SetLayerWeight(2,0);
			moveSpeed = PlayerMovement.originalMoveSpeed;
		}
		else if (fear == 1)
		{
			playerAnim.SetLayerWeight(0,0);
			playerAnim.SetLayerWeight(1,1);
			playerAnim.SetLayerWeight(2,0);
			moveSpeed = PlayerMovement.originalMoveSpeed * fear1multiplier;
		}
		else if (fear == 2)
		{
			playerAnim.SetLayerWeight(0,0);
			playerAnim.SetLayerWeight(1,0);
			playerAnim.SetLayerWeight(2,1);
			moveSpeed = PlayerMovement.originalMoveSpeed * fear2multiplier;
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
        leafDead = true;
		PlayerStats.isInteractive = false;
		PlayerStats.canDie = false;
		PlayerMovement.isClimbing = false;
		PlayerMovement.canClimb = false;
		this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		
		playerAnim.SetBool("isDead",true);
		
		
		Component[] sprites;

		sprites = player.GetComponentsInChildren<SpriteRenderer>();

		foreach (SpriteRenderer renderer in sprites)
		{
			//renderer.enabled = false;
		}



	        GameObject.Find("GameManager").GetComponent<GameManager>().RestartScene();


    }

	public void NoLight()
	{
		
		
		
	}
    public void BurstSpeed() {
        if (!mimLit) {
            moveSpeed += 2;
        }
    }

}
