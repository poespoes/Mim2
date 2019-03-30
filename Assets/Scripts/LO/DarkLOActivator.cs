using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLOActivator : MonoBehaviour
{
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
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<DarkLOSystem>() == false)
            {
                other.gameObject.AddComponent<DarkLOSystem>();
                Debug.Log("Dark LO added");
                
            }
            else
            {
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<DarkLOSystem>() == true)
            {
                //other.gameObject.AddComponent<DarkLOSystem>();
                other.GetComponent<DarkLOSystem>().canDecrease = true;

            }
            
          
                
          
        }
    }
}
