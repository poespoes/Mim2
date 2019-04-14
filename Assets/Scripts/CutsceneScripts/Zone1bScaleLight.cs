using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Zone1bScaleLight : MonoBehaviour
{
    public Transform leaf;
    public bool maxSizeReached;

    public float lightDecreaseAmount;
    private float lightDecreaseActual;
    public bool canLightUp;
    
    
    public MimLightToggle mimLightToggle;
    public GameObject mimLeafGameObject;

    public UnityEvent lightUpEvent;

    
    
    

    // Start is called before the first frame update
    void Start()
    {
        if (lightDecreaseAmount == 0)
        {
            lightDecreaseAmount = 1;
        }
        lightDecreaseActual = lightDecreaseAmount / 100;

        mimLightToggle.enabled = false;
        mimLeafGameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (canLightUp == true)
        {

            if (Input.GetButtonDown("Fire1") && leaf.transform.localScale.x < 1)
            {
                leaf.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

            }


            if (leaf.transform.localScale.x >= 1)
            {

                maxSizeReached = true;
                lightUpEvent.Invoke();


            }


            if (maxSizeReached == false && leaf.transform.localScale.x > 0)
            {
                leaf.transform.localScale -= new Vector3(lightDecreaseActual, lightDecreaseActual, lightDecreaseActual);
            }
        }

    }


    public void CanActivateLight()
    {
        canLightUp = true;

    }

    public void EnableTrueLeaf()
    {
        
        mimLeafGameObject.SetActive(true);
        mimLightToggle.enabled = true;
       
    }

    public void DisableSelf()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    
    public void PlayerEnabled()
    {

        PlayerStats.isInteractive = true;
    }
    
    void LightDeath()
    {
       

    }
}
