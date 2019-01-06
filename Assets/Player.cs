using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    
    public float moveSpeed;
    public float jumpAmount;
    public float horizontalJump;
    float targetPos;
    public float stopPosX;
    public float BufferDistance;
    public bool isWalking;
    public float WalkingState;
    public bool canWalk;
    public GameObject v_Mouse;

    private GameObject blackout;
    public Animator playerAnimator;

    private float velocityX;
    private float velocityY;

    public bool canJump;

    public float playerScaredSpeed;
    public float playerVeryScaredSpeed;


    public bool canClimb;
    public bool isClimbing;

    private float originalGravScale;
    public AnimationCurve curve;
    private float originalDrag;

    public bool isLIt;
    public bool invulnerable;

    public bool canDie;
    public float respawnTime;
    public GameObject VineChase;

    public bool noLeaf;

    public bool canGrab;
    public bool isGrabbing;

    public bool isDying;

    void Start() {
        targetPos = transform.position.x;
        WalkingState = this.GetComponent<PlayerAnimation>().WalkingState;
        canWalk = true;
        
        v_Mouse = GameObject.Find("VirtualMouse");
        blackout = GameObject.Find("BlackoutPanel");

        playerAnimator = this.GetComponent<Animator>();
        
        originalGravScale = this.GetComponent<Rigidbody2D>().gravityScale;
        originalDrag = this.GetComponent<Rigidbody2D>().drag;

        isLIt = true;
        invulnerable = false;

    }

    void Update()
    {
     
        
        if (this.GetComponent<Rigidbody2D>().velocity.y > 0.001f || this.GetComponent<Rigidbody2D>().velocity.y < -0.001f )
        {
            playerAnimator.SetBool("MimJumping",true);
            Debug.Log("I am falling because my speed is " );
            /*this.GetComponent<Rigidbody2D>().gravityScale =
                Mathf.Lerp((originalGravScale / 2), originalGravScale, Time.deltaTime*30);*/

            float newGrav = curve.Evaluate(Mathf.PingPong(Time.deltaTime, 1));
            this.GetComponent<Rigidbody2D>().gravityScale = newGrav*10.0f;
            this.GetComponent<Rigidbody2D>().drag = 0;

        }
        else
        {
            playerAnimator.SetBool("MimJumping",false);
            Debug.Log("I have stopped falling");
            this.GetComponent<Rigidbody2D>().gravityScale = originalGravScale;
            this.GetComponent<Rigidbody2D>().drag = originalDrag;
        }
        
        if (Input.GetKeyDown(KeyCode.G)) {
            canJump = true;
        }
        
        if (canWalk == true)
        {
            
            
            /*
            if (Input.GetMouseButtonDown(0))
            {
                isWalking = true;
                this.GetComponent<PlayerAnimation>().WalkingState = 1;
                //targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - BufferDistance;
                
                targetPos = v_Mouse.transform.position.x - BufferDistance;
                //Debug.Log("Moving to" + targetPos);
            }
            */

           /* if (Input.GetAxisRaw("Horizontal") != 0)
            {
                
                isWalking = true;
                this.GetComponent<PlayerAnimation>().WalkingState = 1;
                
                targetPos = (this.transform.position.x + Input.GetAxis("Horizontal"));
                //Debug.Log("Moving to" + targetPos);
                
                playerAnimator.SetBool("MimIsWalking",true);
                Debug.Log("Is Walking");
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    this.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().flipX = true;
                }
                
                Debug.Log("MOve speed is " + moveSpeed);
            }
            else
            {
                playerAnimator.SetBool("MimIsWalking",false);
                Debug.Log("Not Walking");
            }*/
            
            
            if (Input.GetAxisRaw("Horizontal")!=0 && canWalk == true && canJump == true) //NEW WALKING SCRIPT
            {
                isWalking = true;
                this.GetComponent<PlayerAnimation>().WalkingState = 1;
                float YSpeed = this.GetComponent<Rigidbody2D>().velocity.y;
                
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,Mathf.Lerp(0, Input.GetAxis("Vertical")* moveSpeed, 0.8f));
                
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal")* moveSpeed, 0.8f),
                    YSpeed);
                
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                
                playerAnimator.SetBool("MimIsWalking",true);
                Debug.Log("Is Walking");
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    this.GetComponent<SpriteRenderer>().flipX = false;
                    GameObject.Find("MimLeaf/Leaf").GetComponent<SpriteRenderer>().flipX = false;
                    this.transform.Find("MimHL").GetComponent<SpriteRenderer>().flipX = false;

                }
                else
                {
                    this.GetComponent<SpriteRenderer>().flipX = true;
                    GameObject.Find("MimLeaf/Leaf").GetComponent<SpriteRenderer>().flipX = true;
                    this.transform.Find("MimHL").GetComponent<SpriteRenderer>().flipX = true;
                }

            }
            else
            {
                this.GetComponent<PlayerAnimation>().WalkingState = 0;
                playerAnimator.SetBool("MimIsWalking",false);
                Debug.Log("Not Walking");
            }

        }

       /* if (canWalk == true) {
            float posX = transform.position.x;
            posX = Mathf.MoveTowards(posX, targetPos, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(posX, transform.position.y);
        }*/ 

        if(canWalk == false) {
            Debug.Log("canWalk = false");
            //blackout.GetComponent<Canvas>().sortingOrder = 99;
            //blackout.GetComponent<Image>().CrossFadeAlpha(255, 2.0f, false);
            //transform.position = new Vector3(transform.position.x, transform.position.y);
            //this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            
        }
        //Mim trips
        /*if (transform.position.x >= stopPosX) {
            Destroy(gameObject);
            //tell the other animator to play the falldown animation

        }*/


        if (transform.position.x == targetPos) {
            //WalkingState = 0;

            this.GetComponent<PlayerAnimation>().WalkingState = 0;
            Debug.Log("stop walking");
        }

        velocityY = this.GetComponent<Rigidbody2D>().velocity.y;
       
        /*if (velocityY == 0)
        {
            
            canJump = true;
        }
        else
        {
            Debug.Log("I CANNOT JUMP");
            canJump = false;
            playerAnimator.SetBool("MimJumping",false);
        }*/


        Vector3 RayCastPoint = new Vector3(transform.position.x, transform.position.y+1,transform.position.z);
        RaycastHit2D hit = Physics2D.Raycast(RayCastPoint, Vector2.down, 1f);
       /* if (hit != null)
        {
            Debug.Log(hit.collider.name);

            if (hit.collider.transform.tag == "ground")
            {
                Debug.Log("Raycast touching ground");

            }
        }*/


        

        Jump();

        
        

        if (canClimb == true)
        {
            if (Input.GetAxisRaw("Vertical") > 0 || canJump ==false)
            {
                Debug.Log("The Climb begins");
                isClimbing = true;


            }

            
        }
        else
        {
            isClimbing = false;
        }
        
        if (isClimbing == true)
        {
            playerAnimator.SetBool("MimJumping",false);
            canWalk = false;
            
            if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal")!=0)
            {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,Mathf.Lerp(0, Input.GetAxis("Vertical")* moveSpeed, 0.8f));
                
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal")* moveSpeed, 0.8f),
                    Mathf.Lerp(0, Input.GetAxis("Vertical")* moveSpeed, 0.8f));
                
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            }
            else
            {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezePositionX|RigidbodyConstraints2D.FreezeRotation;
                //this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }

            canJump = true;
        }
        else
        {
            //this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            canWalk = true;
        }
        
        playerAnimator.SetBool("MimClimbing",isClimbing);
    }

    public void Say() {
        Debug.Log("trytguhinuj");
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump")) //JUMPING!!!!!
        {
            if (canJump == true)
            {
                canJump = false;
                //Debug.Log("I CAN JUMP");
                //this.GetComponent<Rigidbody2D>().AddForce((Vector2.up)*100*jumpAmount);
                float currentXVelocity = this.GetComponent<Rigidbody2D>().velocity.x;
                
              
                //JumpModes
                
                //this.GetComponent<Rigidbody2D>().velocity = new Vector2(currentXVelocity, jumpAmount);  //Velocity
                //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpAmount*3), ForceMode2D.Impulse); //Impulse
                
                //this.GetComponent<Rigidbody2D>().gravityScale = originalGravScale/2;
                //this.GetComponent<Rigidbody2D>().AddForce(Vector2.Lerp(Vector2.zero,new Vector2(0,jumpAmount*250), Time.deltaTime/1.5f), ForceMode2D.Impulse); //Acceleration
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpAmount*100), ForceMode2D.Force);
                
                //this.GetComponent<PlayerAnimation>().WalkingState = 4;
                playerAnimator.SetBool("MimJumping",true);

                isClimbing = false;

                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpAmount*Input.GetAxisRaw("Horizontal"), jumpAmount), ForceMode2D.Impulse);
                    //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalJump*Input.GetAxisRaw("Horizontal")*25, jumpAmount*105), ForceMode2D.Force);
                    
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal")* moveSpeed, 0.8f),
                        this.GetComponent<Rigidbody2D>().velocity.y);
                    
                    Debug.Log("Moving forward");
                }
                else
                {
                    //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpAmount*3), ForceMode2D.Impulse);
                   
                }


            }
            else
            {
                //Debug.Log("Can't Jump");
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided");
        
        Vector2 normal = other.contacts[0].normal;

        if (other.gameObject.tag == "ground" && normal.y > Mathf.Abs(normal.x))
        {
           canJump = true;
           playerAnimator.SetBool("MimJumping",false);
           isClimbing = false;
        }
    }

    public void Die()
    {
        if (canDie == false)
       {
           Invoke("Restart", respawnTime);
           this.GetComponent<Animator>().SetBool("MimDying",true);

            gameState gamestate = GameObject.Find("GameManager").GetComponent<gameState>();
            gamestate.interactive = false;

            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < sprites.Length; i++)
            {
                //sprites[i].enabled = false;
                sprites[i].DOColor(Color.black, 1.5f);
            }

            canDie = true;
           isDying = true;
           
       }
    }

    public void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        
        
        if (VineChase != null)
        {
            VineChase.GetComponent<VineReset>().Reset();
        }
        
        CheckPointManager _checkPointManager = GameObject.Find("GameManager").GetComponent<CheckPointManager>();
        this.transform.position = _checkPointManager.lastCheckPoint;
        
        gameState gamestate = GameObject.Find("GameManager").GetComponent<gameState>();
        gamestate.interactive = true;
        
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].DOColor(Color.white, 0.5f);
        }

        canDie = false;
        this.GetComponent<Animator>().SetBool("MimDying",false);

        isDying = false;
    }
    
    

    /* private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Tripping") {
            Debug.Log("tripping");

            GameObject trip = GameObject.Find("TripAnimation");
            trip.GetComponent<Animate>().tripping = true;
            //Destroy(gameObject);
            this.transform.position = new Vector2(136.4f, -10.5f);
            this.gameObject.SetActive(false);
        }
    }*/
}
