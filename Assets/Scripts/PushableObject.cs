using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    public bool beingPushed;
    public Vector2 myVector;
    public bool slowDownTriggered;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beingPushed == false)
        {
      
            DOTween.To(()=> myVector, x=> myVector = x, new Vector2(0,0), 2);
            this.GetComponent<Rigidbody2D>().velocity = myVector;
        }
    }

    public void SlowDown()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            beingPushed = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            beingPushed = false;
        }
    }
}
