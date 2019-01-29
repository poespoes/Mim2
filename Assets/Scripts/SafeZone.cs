using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
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
        if (other.GetComponent<OIMonster>() != null)
        {
            other.GetComponent<OIMonster>().Die();
        }

        if (other.tag == "OIMonster")
        {
            Debug.Log("SafeZoneBreached");
            other.GetComponent<OIMonster>().Die();
        }
    }
}
