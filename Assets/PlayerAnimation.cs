using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    public Animator PlayerAnimator;
    private SpriteRenderer sr;
    public float WalkingState = 0;
    public float movingSpeed;

    public Player player;
    
    

    // Use this for initialization
    void Start() {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Player>();
        movingSpeed = player.moveSpeed;
    }

    // Update is called once per frame
    void Update() {
        if (WalkingState == 0) {
            PlayerAnimator.SetBool("MimWalk", false);
            PlayerAnimator.SetBool("MimScareWalk", false);
            PlayerAnimator.SetBool("MimVeryScareWalk", false);
        }
        if (WalkingState == 1 && this.GetComponent<Player>().isWalking == true) {
            PlayerAnimator.SetBool("MimWalk", true);
            PlayerAnimator.SetBool("MimScareWalk", false);
            PlayerAnimator.SetBool("MimVeryScareWalk", false);
            player.moveSpeed = movingSpeed;
        }
        if (WalkingState == 2 && this.GetComponent<Player>().isWalking == true) {
            PlayerAnimator.SetBool("MimWalk", false);
            PlayerAnimator.SetBool("MimScareWalk", true);
            PlayerAnimator.SetBool("MimVeryScareWalk", false);
            player.moveSpeed = player.playerScaredSpeed;
        }
        if (WalkingState == 3 && this.GetComponent<Player>().isWalking == true) {
            PlayerAnimator.SetBool("MimWalk", false);
            PlayerAnimator.SetBool("MimScareWalk", false);
            PlayerAnimator.SetBool("MimVeryScareWalk", true);
            player.moveSpeed = player.playerVeryScaredSpeed;
        }
        if (WalkingState == 4 && this.GetComponent<Player>().isWalking == true) {
            PlayerAnimator.SetBool("MimWalk", false);
            PlayerAnimator.SetBool("MimScareWalk", false);
            PlayerAnimator.SetBool("MimVeryScareWalk", false);
            PlayerAnimator.SetBool("MimJumping",true);
        }

        if (WalkingState == 5 && this.GetComponent<Player>().isWalking == true)
        {
            player.moveSpeed = player.playerScaredSpeed * 4;
        }
        
        if (WalkingState == 6 && this.GetComponent<Player>().isWalking == true)
        {
            
            PlayerAnimator.SetBool("MimWalk", false);
            PlayerAnimator.SetBool("MimScareWalk", false);
            PlayerAnimator.SetBool("MimVeryScareWalk", false);
            PlayerAnimator.SetBool("MimJumping",false);
            PlayerAnimator.SetBool("MimLedgeGrab",true);
            //player.moveSpeed = player.playerScaredSpeed * 4;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        //collide fearstate2
        
        if (collision.gameObject.tag == "FearState3") {
            Debug.Log("Walking State = 3");
            WalkingState = 3;
        } else {
            if (collision.gameObject.tag == "FearState2") {
                Debug.Log("Walking State = 2");
                WalkingState = 2;
            }
        }
    }

        private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "FearState2" || collision.gameObject.tag == "FearState3") {
            Debug.Log("Walking State = 1");
            WalkingState = 1;
        }
    }

}
