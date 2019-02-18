using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorHere : MonoBehaviour
{
    public Vector3 anchorPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        anchorPoint = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = anchorPoint;
    }

    private void LateUpdate()
    {
        
    }
}
