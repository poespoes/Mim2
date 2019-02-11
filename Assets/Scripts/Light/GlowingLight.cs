using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingLight : MonoBehaviour
{

    public bool canBeLit;
    public bool objectLit;
    public VineChase vineChase;
    public bool hasDied;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Playere entered");
            canBeLit = true;
        }
    }

    public void LightUp()
    {
        objectLit = true;
        this.GetComponent<Animator>().SetBool("LightON",true);
        this.GetComponent<Animator>().SetBool("LightOFF",false);
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
