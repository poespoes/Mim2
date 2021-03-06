﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineTargetOverdrive : MonoBehaviour
{
    public VineChase _vineChase;
    
    // Start is called before the first frame update
    void Start()
    {
        _vineChase = this.GetComponent<VineChase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "LightObject" && other.GetComponent<GlowingLight>() == true)
        {
            _vineChase.lighObjectFound = true;
            _vineChase.distraction = other.transform;
            other.GetComponent<GlowingLight>().vineChase = _vineChase;
            Debug.Log("Distraction found");
        }
    }
}
