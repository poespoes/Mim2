using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineSpawnScript : MonoBehaviour
{
	public float spawnDelay;
	public GameObject objectToSpawn;

	// Use this for initialization
	void Start () {
		objectToSpawn.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartSpawn()
	{
		Invoke("Spawn",spawnDelay);
	}

	public void Spawn()
	{
		objectToSpawn.SetActive(true);
	}
}
