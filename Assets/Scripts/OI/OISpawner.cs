using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OISpawner : MonoBehaviour
{

	public float spawnTime;
	public float timer;
	
	public float minSpawnDistance;
	public float currentDistance;
	public float maxDistance;
	
	public Transform playerTransform;
	public GameObject _mySon;

	public bool canSpawnOI;

	public enum TypeOfOI
	{
		Bottle,
		Shoe

	};

	public TypeOfOI _typeOfOI;

	// Use this for initialization
	void Start ()
	{

		playerTransform = PlayerStats.playerTransform;
		timer = spawnTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//currentDistance = Vector2.Distance(playerTransform.position, this.transform.position);

		currentDistance = Mathf.Abs(this.transform.position.x - playerTransform.position.x);

		if (_mySon == null)
		{
			SpawnTimer();
		}
		else
		{
			// DespawnOI();  //if we want the OI to despawn once we've gone far enough away from the original spawner
			timer = spawnTime;
		}


	}

	void SpawnTimer()
	{
		if (currentDistance < minSpawnDistance && PlayerStats.mimLit == false)
		{
			if (timer > 0)
			{
				timer -= Time.deltaTime;
			}
			else
			{
				//SpawnOI();
				this.GetComponent<Animator>().SetBool("isSpawning",true);
				canSpawnOI = true;
				timer = 0;
			}
		}
		else
		{
			if (timer < spawnTime)
			{
				timer += Time.deltaTime;
			}
			else
			{
				
				timer = spawnTime;
			}
		}
	}

	void SpawnOI()
	{
		if (canSpawnOI == true && _mySon == null)
		{

			string _myPath = "Prefabs/OI/" + _typeOfOI.ToString();

			Debug.Log("Spawned from " + _myPath);

			_mySon = GameObject.Instantiate(Resources.Load(_myPath) as GameObject);
			_mySon.transform.SetParent(this.transform, false);
			_mySon.transform.position = this.transform.position;
		}

	}

	public void DespawnOI()
	{
		Debug.Log("Despawn is called");
		if (currentDistance > maxDistance)
		{
			Destroy(_mySon);
			Debug.Log("Despawn succesful");
		}
	}
}
