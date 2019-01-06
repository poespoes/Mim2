using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OI_Body : MonoBehaviour {
    public Animator MonsterAnimator;
    public bool isLitUp = false;
    bool inAtkRange = false;
    private float fearTimer = 0;
    public float maxFearDuration;
    public float speedPercent;
    private float actualSpeed;

    public GameObject parentMonster;

    public GameObject player;
    public GameObject OIMonster;
    public Deathcollider deathCollider;

    public Image blackOutCanvas;

    private bool firstEntered;
    
    

    // Use this for initialization
    void Start ()
    {
        parentMonster = this.transform.parent.gameObject;
        deathCollider = parentMonster.transform.Find("DeathCollider").GetComponent<Deathcollider>();

        player = GameObject.Find("Player");
        MonsterAnimator = this.GetComponent<Animator>();

        blackOutCanvas = GameObject.Find("BlackoutPanel").GetComponent<Image>();

        firstEntered = false;

    }
	
	// Update is called once per frame
	void Update () {
        
        if (deathCollider.deathTriggered == false) {
            MonsterAnimator.SetBool("isWalking", true);
        }

        //if LitUp == false
        // MonsterAnimator.SetBool("isWalking", true);


        if (deathCollider.deathTriggered == true) {
            Debug.Log("Kill!Kill!");
            player.GetComponent<Player>().canWalk = false;
            MonsterAnimator.SetBool("isWalking", false);
            MonsterAnimator.SetBool("isAttacking", true);
            blackOutCanvas.CrossFadeAlpha(255,6,false);
            Invoke("Restart",2.0f);
        }

	    if (player.transform.position.x > transform.position.x)
	    {
	       this.GetComponent<SpriteRenderer>().flipY = true;
	        
	    }
	    else
	    {
	       this.GetComponent<SpriteRenderer>().flipY = false;
	    }
    }



    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "MimLight") {
            Debug.Log("Monster is lit up!");
            isLitUp = true;

            if (firstEntered == false)
            {
                GameObject virtualMouse = GameObject.Find("VirtualMouse");


                firstEntered = true;
            }
            
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
