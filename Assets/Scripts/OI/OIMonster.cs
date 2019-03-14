using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class OIMonster : MonoBehaviour
{

	public float currentDistance;
	public float maxDistance;
	private Sequence chaseSequence;
	private float chaseTime;
	public float speed;
	
	[Range(1,10)]
	public float rampUp;

	public SpriteRenderer _sprite;
	

	// Use this for initialization
	void Start () {
		if (rampUp == 0)
		{
			rampUp = 2;
		}

        
    }
	
	// Update is called once per frame
	void Update () {
		
		if (_sprite == null)
		{
			_sprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
		}
		
		if (currentDistance < maxDistance)
		{
			Chase();
		}
		else
		{
			Die();
		}
		
		DisappearToggle();
	}

	void Chase()
	{
        _sprite.color = new Color(83, 206, 206, 1);      //OI appears

        if (PlayerStats.player.transform.position.x > this.transform.position.x)
		{
			_sprite.flipX = false;
		}
		else
		{
			_sprite.flipX = true;
		}
		
		currentDistance = Vector2.Distance(PlayerStats.playerTransform.position, this.transform.position);
		if (PlayerStats.mimLit == false)
		{
            //chaseSequence.Append(this.transform.DOMoveX(PlayerStats.playerTransform.position.x, chaseTime, false));
            
            float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, PlayerStats.playerTransform.position, step);
			//speed += rampUp*Time.deltaTime; //increase speed over time



		}
		else
		{
			this.transform.position = this.transform.position;
			_sprite.color = new Color(83, 206, 206, 0);      //OI fades away when its not chasing mim

            //chaseSequence.Kill();
        }
		
	}

	public void Die()
	{
		Destroy(this.gameObject);
	}

	void DisappearToggle()
	{
		this.GetComponentInChildren<SpriteRenderer>().enabled = !PlayerStats.mimLit;
		this.GetComponent<Collider2D>().enabled = !PlayerStats.mimLit;
	}
}
