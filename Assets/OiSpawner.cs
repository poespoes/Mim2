using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OiSpawner : MonoBehaviour {

    public float zRotation = 0;
    public float rotationSpd;

    public GameObject OiPrefab;
    private float timer = 0;
    public float spawnInterval = 2;

    private bool isSpawning;
    private bool hasSpawnedIntro;
    public bool triggered;
    public Animator OiAnimator;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

        //If player TRIGGERED Oi
        if (triggered == true && hasSpawnedIntro == false && isSpawning == false) {
            OiAnimator.SetBool("Forming", true);
            timer += Time.deltaTime;
        }
        if(triggered == true && hasSpawnedIntro == true) {
            Debug.Log("IntroSpawn animation stop!");
            OiAnimator.SetBool("Forming", false);
        }

        if (hasSpawnedIntro == true && isSpawning == true && hasSpawnedIntro == true) {
            timer += Time.deltaTime;
            zRotation += rotationSpd;
            transform.eulerAngles = new Vector3(0, 0, zRotation);
        }
        
        if (timer >= spawnInterval && isSpawning == true && hasSpawnedIntro == true) {
            Debug.Log("started spawning");
            GameObject newProjectileObj = Instantiate(OiPrefab, transform.position, transform.rotation);
            newProjectileObj.transform.rotation = transform.rotation;
            timer = 0;
        }

    }

    public void hasSpawnedTrue() {
        hasSpawnedIntro = true;
        isSpawning = true;

        GameObject Forming = GameObject.Find("Forming").gameObject;
        Forming.SetActive(false);
    }
}