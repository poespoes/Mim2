using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingLight : MonoBehaviour
{

    public bool objectLit;
    public VineChase vineChase;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vineChase != null)
        {
           // vineChase.isTriggered = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerStats.mimLit==true)
        {
            Debug.Log("Playere entered");
            objectLit = true;
            this.GetComponent<Animator>().SetBool("LightON",true);
        }
    }

    public void LightUp()
    {
        
    }
}
