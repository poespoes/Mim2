using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRealLeaf : MonoBehaviour
{
    public MimLightToggle mimLightToggle;
    public GameObject mimLeafGameObject;
    //public GameObject mimLightGameObject;
    public IntroScalelightWhenPressed scaleLeaf;

    public float originalMoveSpeed;

    public float timer;
    public float timeTilCanPlay;

    public PlayerMovement PlayerMovement;

    public bool canMove;
    
    // Start is called before the first frame update

    private void Awake()
    {
        /*
        originalMoveSpeed = PlayerStats.moveSpeed;
        
        
        mimLightToggle.enabled = false;
        mimLeafGameObject.SetActive(false);
        //mimLightGameObject.SetActive(false);
        scaleLeaf.enabled = false;

        PlayerMovement = PlayerStats.player.GetComponent<PlayerMovement>();

        canMove = false;
        PlayerMovement.enabled = false;*/


    }

    void Start()
    {
        canMove = false;
        PlayerMovement.enabled = false;
        
        originalMoveSpeed = PlayerStats.moveSpeed;
        
        
        mimLightToggle.enabled = false;
        mimLeafGameObject.SetActive(false);
        //mimLightGameObject.SetActive(false);
        scaleLeaf.enabled = false;

        PlayerMovement = PlayerStats.player.GetComponent<PlayerMovement>();

        canMove = false;
        PlayerMovement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        //timer >= timeTilCanPlay

        if (PlayerStats.isInteractive == true)
        {
            scaleLeaf.enabled = true;
        }
        
        if (scaleLeaf.maxSizeReached == true)
        {
            mimLightToggle.enabled = true;
            mimLeafGameObject.SetActive(true);
            //mimLightGameObject.SetActive(true);
            Destroy(scaleLeaf.gameObject);

            canMove = true;
            PlayerMovement.enabled = true;
        }

        PlayerMovement.enabled = canMove;
    }
}
