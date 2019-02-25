using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVineTrigger : MonoBehaviour
{
    public MoveTowardsPlayer moveTowardsPlayer;
    public Transform target;
    public bool targetOverride;
    public bool foundLight;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            moveTowardsPlayer.target = target;
        }

        if (foundLight == true)
        {
            moveTowardsPlayer.isTriggered = true;
        }
        else
        {
            moveTowardsPlayer.isTriggered = false;
        }

        if (target.gameObject.GetComponent<PlayerStats>() != null)
        {
            if (PlayerStats.mimLit == true)
            {
                foundLight = true;
            }
            else
            {
                foundLight = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerStats>() != null && targetOverride == false)
        {
            target = other.transform;
            //moveTowardsPlayer.isTriggered = true;    
        }
        else if (other.gameObject.GetComponent<GlowingLight>() != null)
        {
            target = other.transform;
            targetOverride = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerStats>() != null && targetOverride == false)
        {
            target = other.transform;
            //moveTowardsPlayer.isTriggered = false;
        }
    }
}
