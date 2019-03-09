using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVineTrigger : MonoBehaviour
{
    public MoveTowardsPlayer moveTowardsPlayer;
    public Transform target;
    public bool targetOverride;
    public bool foundLight;
    public Transform inactiveTarget;
    
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

        if (target != null && target.gameObject.GetComponent<PlayerStats>() != null)
        {
            if (PlayerStats.mimLit == true && target!=null)
            {
                foundLight = true;
            }
            else
            {
                Debug.Log("Withdraw Vine");
                foundLight = false;
            }
        }

        if (inactiveTarget.GetComponent<GlowingLight>()!=null && inactiveTarget.GetComponent<GlowingLight>().objectLit)
        {
            ChaseOtherLight(inactiveTarget.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (targetOverride == false)
        {


            if (other.gameObject.GetComponent<PlayerStats>() != null && targetOverride == false)
            {
                target = other.transform;
                //moveTowardsPlayer.isTriggered = true;    
            }
            else if (other.gameObject.GetComponent<GlowingLight>() != null)
            {
                if (other.gameObject.GetComponent<GlowingLight>().objectLit == true)
                {
                    /*target = other.transform;
                    foundLight = true;
                    targetOverride = true;*/

                    ChaseOtherLight(other.gameObject);
                }
                else
                {
                    inactiveTarget = other.transform;
                }

            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<GlowingLight>() != null)
        {
            inactiveTarget = other.transform;
        }
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerStats>() != null && targetOverride == false)
        {
            //target = other.transform;
            foundLight = false;
            target = null;
            //moveTowardsPlayer.isTriggered = false;
        }
    }

    
    public void ChaseOtherLight(GameObject other)
    {
        target = other.transform;
        foundLight = true;
        targetOverride = true;
    }

    public void CheckWithinTrigger()
    {
        
    }
}
