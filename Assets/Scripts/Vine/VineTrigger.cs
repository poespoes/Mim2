using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineTrigger : MonoBehaviour
{

    public VineChase _VineChase;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _VineChase.isTriggered = true;
            _VineChase.target = PlayerStats.playerTransform;
        }
        
        if (other.gameObject.GetComponent<GlowingLight>() != null)
        {
            Debug.Log("Light Object Found");
                
            if (other.gameObject.GetComponent<GlowingLight>().objectLit == true)
            {
                _VineChase.isTriggered = true;
                _VineChase.target = other.transform;
            }
        }
  
           
      
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _VineChase.isTriggered = false;
            _VineChase.target = null;
        }
    }
}
