using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineVariantSpeed : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
        if (speed == null)
        {
            speed = 1;
        }

        this.GetComponent<Animator>().speed = speed;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
	
	
}
