using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineTargetOverdrive : MonoBehaviour
{
    public VineChase _vineChase;
    
    // Start is called before the first frame update
    void Start()
    {
        _vineChase = this.GetComponent<VineChase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<GlowingLight>() == true)
        {
            _vineChase.lighObjectFound = true;
            _vineChase.distraction = other.transform;
            Debug.Log("Distraction found");
        }
    }
}
