using System.Collections;
using System.Collections.Generic;
using Cinemachine.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Animate : MonoBehaviour {
    public Animator TripAnimator;
    public bool tripping = false;
    public GameObject TrippedMim;
    public GameObject m_player;
    public Animator PodLight;
   
    public GameObject trip_camera2;
    public GameObject blackout;
    public GameObject v_Mouse;
    public Sprite sprite1;

    public letThereBeLight lightBringer;
    
    
    // Use this for initialization
    void Start () {
        m_player = GameObject.Find("Player");
        
        trip_camera2 = GameObject.Find("Trip2");

        blackout = GameObject.Find("BlackoutPanel");

        v_Mouse = GameObject.Find("VirtualCamera");

        lightBringer = GameObject.Find("GameManager").GetComponent<letThereBeLight>();
        
        trip_camera2.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (tripping == true) {
            Debug.Log("tripping");
            TripAnimator.SetBool("MimTrip", true);
            
            
        }

    }
    void spawnTrippedMim() {
        //TrippedMim.SetActive(true);
        m_player.GetComponent<SpriteRenderer>().sprite = sprite1;
        m_player.SetActive(true);


        
    }

    void cameraActivate()
    {
        //trip_camera2.SetActive(true);
    }

    void fadeOut()
    {
        //GameObject.Find("BlackoutPanel").GetComponent<UICrossFade>().willFadeOut = true;
        Debug.Log("BlackoutSent");
        
        GameObject.Find("GameManager").GetComponent<gameState>().interactive = false;
        blackout.GetComponent<Image>().CrossFadeAlpha(255,5.0f,false);

        //blackout.GetComponent<UICrossFade>().willFadeOut=true;
    }

    void podGlow()
    {
        //v_Mouse.transform.position = new Vector3(-15,-6);
        lightBringer.canActivate = true;
        PodLight.SetBool("isGlowing",true);
        GameObject.Find("Vine").GetComponent<vineAttack>().canAttack = true;
        Destroy(gameObject);

        
    }
}
