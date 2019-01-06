using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OI_RootMonster : MonoBehaviour {
    private float fearTimer = 0;
    public float maxFearDuration;
    public float speedPercent;
    private float actualSpeed;

    public GameObject player;
    public OI_Body OIbody;

    public float distance;
    public PlayerAnimation playerAnim;

    void Start () {
        player = GameObject.Find("Player");
        actualSpeed = (speedPercent / 100) * 1;
        OIbody = transform.Find("Body").GetComponent<OI_Body>();
        playerAnim = player.GetComponent<PlayerAnimation>();
    }


    void Update() {
        
        //Running to the player
        if (OIbody.isLitUp == false) {
            Debug.Log("Moving Towards Player!");
            
            /*transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(player.transform.position.x, transform.position.y), actualSpeed);*/

            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(player.transform.position.x, player.transform.position.y), actualSpeed);

            //Vector3 moveDir = player.transform.position - transform.position;\
            Vector3 moveDir = transform.position - player.transform.position;
            
            if (moveDir != Vector3.zero) 
            {
                float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

        }
        
        if (OIbody.isLitUp == true) {
            Debug.Log("Running away!");
            fearTimer += Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(player.transform.position.x, player.transform.position.y), -1*actualSpeed);
            
            
        }

        //if ran away > maxfearduration and no longer collided with mimlight, then feartimer resets
        if (fearTimer >= maxFearDuration) {
            fearTimer = 0;
            OIbody.isLitUp = false;
        }


        //distance = Vector3.Distance(this.transform.position, player.transform.position);

        distance = Vector2.Distance(transform.position,
            new Vector2(player.transform.position.x, transform.position.y));
        
        //Debug.Log(distance + "metres away. Gonna getch ya");

        if (distance < 30)
        {
            Debug.Log("WARNING WAAAAY TOO CLOSE");
            playerAnim.WalkingState = 3;
        }
        else if(distance < 50)
        {
            Debug.Log("WARNING TOO CLOSE");
            playerAnim.WalkingState = 2;
        }
        else
        {
            //playerAnim.WalkingState = 1;
        }
    }



}
