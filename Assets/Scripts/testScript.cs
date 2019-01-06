using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {
    public Animator MonsterAnimator;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MonsterAnimator.SetBool("isWalking", true);
    }
}
