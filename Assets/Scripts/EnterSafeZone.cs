using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Cinemachine.Editor;

public class EnterSafeZone : MonoBehaviour
{
    public CinemachineVirtualCamera cm2;
    public int priority;
    public bool dynamic;
    
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
            cm2.Priority = priority;

            if (dynamic == true)
            {
                cm2.m_Follow = other.transform;
            }
            
        }
    }
}
