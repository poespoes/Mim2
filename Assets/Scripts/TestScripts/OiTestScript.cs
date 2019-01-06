using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OiTestScript : MonoBehaviour {
    public GameObject MonsterPrefab;

    // Use this for initialization
    void Start () {
        Debug.Log("Monster spawns!");
        GameObject newMonsterObj = Instantiate(MonsterPrefab);
        //hasSpawned = true;
        newMonsterObj.transform.position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
