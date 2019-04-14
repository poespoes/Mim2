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
    
    // Start is called before the first frame update

    private void Awake()
    {
        originalMoveSpeed = PlayerStats.moveSpeed;
        
        
        mimLightToggle.enabled = false;
        mimLeafGameObject.SetActive(false);
        //mimLightGameObject.SetActive(false);
        scaleLeaf.enabled = false;

        PlayerMovement = PlayerStats.player.GetComponent<PlayerMovement>();

        PlayerMovement.enabled = false;


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (PlayerStats.isInteractive == true && timer >= timeTilCanPlay)
        {
            scaleLeaf.enabled = true;
        }
        
        if (scaleLeaf.maxSizeReached == true)
        {
            mimLightToggle.enabled = true;
            mimLeafGameObject.SetActive(true);
            //mimLightGameObject.SetActive(true);
            Destroy(scaleLeaf.gameObject);

            PlayerMovement.enabled = true;
        }
    }
}
