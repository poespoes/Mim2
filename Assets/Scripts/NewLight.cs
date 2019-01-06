using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NewLight : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    public Vector3 TargetScale = new Vector3(1f, 1f, 1f);
    public Vector3 StartingScale = new Vector3(5f, 5f, 5f);
    public float TimeToScale = 5.0f;

    public bool isScalingDown;
    private float dimTime = 0.0f;
    private float dimTime2 = 0.0f;

    private Color originalColor;
    public Color darkenedColor;

    public GameObject player;
    public GameObject mimLeaf;
    public GameObject mimLeaf2;

    public float tweenTime;

    public bool isTransforming;

    public gameState g_state;
    public bool interactive;
    public bool noLeaf;
    
    private void Start() {
        player = GameObject.Find("Player");
        mimLeaf = GameObject.Find("Leaf");
        
        
        transform.localScale = StartingScale;
        //isScalingDown = true;
        originalColor = player.GetComponent<SpriteRenderer>().color;

        g_state = GameObject.Find("GameManager").GetComponent<gameState>();
        
    }

    private void Update() {
        interactive = g_state.interactive;

        noLeaf = player.GetComponent<Player>().noLeaf;


        mimLeaf.GetComponent<SpriteRenderer>().enabled = !noLeaf;
       
        
        if (isScalingDown==true) {
            dimTime += Time.deltaTime / TimeToScale;
            if (dimTime >= 1.0f) {
                transform.localScale = TargetScale;
                isScalingDown = false;
                
                
                

            } else {
                transform.localScale = Vector3.Lerp(StartingScale, TargetScale, dimTime);
                

            }
        }
        else
        {
            dimTime2 += Time.deltaTime / TimeToScale;


            
           
        }

        if (interactive == true)
        {
            if (noLeaf == false)
            {
                if (isTransforming == false)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        isScalingDown = false;
                        Debug.Log("Light is not shrinking");
                        LightOff();


                    }
                    else
                    {
                        isScalingDown = true;
                        LightOn();
                    }
                }
            }
        }
    }

    public void LightOff()
    {
        //put light off script here
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.transform.parent.GetComponent<Player>().isLIt = false;
        
        //player.GetComponent<SpriteRenderer>().color = darkenedColor;
        player.GetComponent<SpriteRenderer>().DOColor(darkenedColor, tweenTime);
        //mimLeaf.GetComponent<SpriteRenderer>().color = darkenedColor;
        mimLeaf.GetComponent<SpriteRenderer>().DOColor(darkenedColor, tweenTime);
  
        mimLeaf.transform.parent.GetComponent<Animator>().SetBool("MimLightOn",false);

    }
    
    public void LightOn()
    {
        //put light off script here
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.transform.parent.GetComponent<Player>().isLIt = true;


        player.GetComponent<SpriteRenderer>().DOColor(originalColor, tweenTime);
        //player.GetComponent<SpriteRenderer>().color = originalColor;
        mimLeaf.GetComponent<SpriteRenderer>().DOColor(originalColor, tweenTime);
        //mimLeaf.GetComponent<SpriteRenderer>().color = originalColor;
        
        mimLeaf.transform.parent.GetComponent<Animator>().SetBool("MimLightOn",true);
       
       
    }

    public void TransformComplete()
    {
        isTransforming = false;
    }
}

