using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScalelightWhenPressed : MonoBehaviour
{
    public Transform leaf;
    public bool maxSizeReached;

    public float lightDecreaseAmount;
    private float lightDecreaseActual;


    public Animator vineAnim;
    // Start is called before the first frame update
    void Start()
    {
        if (lightDecreaseAmount == 0)
        {
            lightDecreaseAmount = 1;
        }
        lightDecreaseActual = lightDecreaseAmount / 100;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && leaf.transform.localScale.x < 1)
        {
            leaf.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
           
        }


        if (leaf.transform.localScale.x >= 1)
        {

            maxSizeReached = true;
            LightDeath();

        }


        if (maxSizeReached == false && leaf.transform.localScale.x > 0)
        {
            leaf.transform.localScale -= new Vector3(lightDecreaseActual,lightDecreaseActual,lightDecreaseActual);
        }


    }


    void LightDeath()
    {
        vineAnim.SetTrigger("playAnimation");
    }
}
