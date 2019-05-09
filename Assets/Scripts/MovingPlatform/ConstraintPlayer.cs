using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintPlayer : MonoBehaviour
{
    public GameObject Mim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Mim.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
            
    }
}
