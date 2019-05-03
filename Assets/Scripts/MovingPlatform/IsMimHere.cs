using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMimHere : MonoBehaviour
{
    public Animator Anim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Anim.SetTrigger("isMoving");
            other.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") {
           
            other.transform.SetParent(null);
        }
    }
}
