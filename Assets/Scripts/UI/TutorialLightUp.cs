﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLightUp : MonoBehaviour
{
    public IntroScalelightWhenPressed script;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (script.maxSizeReached) {
            this.gameObject.SetActive(false);
        }
    }
}
