using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericEventActivator : MonoBehaviour
{
    public UnityEvent unityEvents;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartEvents()
    {
        unityEvents.Invoke();
    }
    
    
}
