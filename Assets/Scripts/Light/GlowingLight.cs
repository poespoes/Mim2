using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingLight : MonoBehaviour
{

    public bool canBeLit;
    public bool objectLit;
    public VineChase vineChase;
    public bool hasDied;
    public bool forceLight;
    public float lightDetectionRadius;
    
    // Start is called before the first frame update
    void Start()
    {
        if (lightDetectionRadius == 0)
        {
            lightDetectionRadius = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (vineChase != null)
        {
           // vineChase.isTriggered = true;
        }*/

        if (canBeLit == true && PlayerStats.mimLit==true && hasDied==false)
        {
            LightUp();
            
        }
        else if (forceLight == true)
        {
            LightUp();

        }

        Collider2D[] coll = Physics2D.OverlapCircleAll(this.transform.position, lightDetectionRadius);

        for (int i = 0; i < coll.Length; i++)
        {
            if (coll[i].GetComponent<GlowingLight>() != null)
            {
                if (coll[i].GetComponent<GlowingLight>().objectLit == true)
                {
                    forceLight = true;
                }
            }
        }
            
       
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Playere entered");
            canBeLit = true;
        }

        else if (other.CompareTag("Vine"))
        {
            Debug.Log("Vine entered");
            
            this.transform.parent.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            
        }
    }

    public void LightUp()
    {
        objectLit = true;
        this.GetComponent<Animator>().SetBool("LightON",true);
        this.GetComponent<Animator>().SetBool("LightOFF",false);
        this.GetComponent<BoxCollider2D>().isTrigger = true;
        this.gameObject.tag = "LightObject";    //Poe added this to let the vine chase light object
        
    }

    public void LightOff()
    {
        hasDied = false;
        objectLit = true;
        this.GetComponent<Animator>().SetBool("LightOFF",true);
        this.GetComponent<Animator>().SetBool("LightON",false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Playere entered");
            canBeLit = false;
        }
    }
}
