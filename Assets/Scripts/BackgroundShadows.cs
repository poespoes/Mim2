﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BackgroundShadows : MonoBehaviour
{

    public SpriteRenderer _frame1;
    public SpriteRenderer _frame3;
    public float alpha;

    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        alpha = _frame1.color.a; 
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (PlayerStats.mimLit == true)
        {
            _frame1.DOFade(alpha, 0.25f);
            _frame3.DOFade(0, 0.5f);
        }
        else
        {
            
            _frame1.DOFade(0, 0.5f);
            _frame3.DOFade(alpha, 0.25f);
        }*/
    }

    private void LateUpdate()
    {
        
            if (PlayerStats.mimLit == true)
            {
                anim.SetBool("FrameLightON",true);
                anim.SetBool("FrameLightOFF",false);
            }
            else
            {
                anim.SetBool("FrameLightON",false);
                anim.SetBool("FrameLightOFF",true);
                
            }
        
    }

    public void CanToggle()
    {
        PlayerStats.canToggle = true;
    }

    public void NoToggle()
    {
        PlayerStats.canToggle = false;
    }
    
}
