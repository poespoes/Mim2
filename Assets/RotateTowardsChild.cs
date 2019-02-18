using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class RotateTowardsChild : MonoBehaviour
{
    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = this.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = target.position - transform.position;
    }
}
