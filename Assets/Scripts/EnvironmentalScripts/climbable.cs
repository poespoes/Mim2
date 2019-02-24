using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbable : MonoBehaviour
{
    public float gravityScale;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gravityScale == null)
        {
            gravityScale = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.canClimb == true && Input.GetAxisRaw("Vertical")>0)
        {
            PlayerMovement.isClimbing = true;
            PlayerMovement.climbToggle = true;

        }
        else if ((PlayerMovement.canClimb == true))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                PlayerMovement.isClimbing = true;
                //PlayerStats.player.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement.canClimb = true;
            gravityScale = other.GetComponent<Rigidbody2D>().gravityScale;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement.canClimb = false;
            PlayerMovement.isClimbing = false;
            PlayerMovement.climbToggle = false;
            other.GetComponent<Rigidbody2D>().gravityScale = gravityScale;

        }
    }
}
