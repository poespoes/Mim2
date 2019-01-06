using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour {

    [SerializeField] float strength;
    [SerializeField] int vibrato;
    [SerializeField] float duration;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F))
        Shake();
	}

    public void Shake() {
        transform.DOShakePosition(duration, strength, vibrato, 90, false, true);
    }
}
