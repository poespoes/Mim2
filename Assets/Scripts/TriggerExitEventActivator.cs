using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerExitEventActivator : MonoBehaviour
{
    public UnityEvent triggerExitUnityEvent;

    public UnityEvent triggerEnterUnityEvent;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartExitEvents();
        }
    }
    
    public void StartExitEvents()
    {
        if (triggerExitUnityEvent != null)
        {
            triggerExitUnityEvent.Invoke();
        }
        
    }

    public void StartEnterEvents()
    {
        if (triggerEnterUnityEvent != null)
        {
            triggerEnterUnityEvent.Invoke();
        }
    }
}
