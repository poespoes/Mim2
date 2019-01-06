using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

    [FMODUnity.EventRef]
    public string inputsound;
    bool playerIsMoving;
    public float walkingSpeed;

    void Update()
    {
        if (Input.GetAxis ("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= 0.01f || Input.GetAxis("Horizontal") <= 0.01f)
        {
            Debug.Log("MIM is Moving");
            playerIsMoving = true;
        }
        else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            Debug.Log("MIM is NOT Moving");
            playerIsMoving = false;
        }
    }

    void CallFootsteps()
    {
        if(playerIsMoving == true)
        {
            Debug.Log("footstep sounds");
            FMODUnity.RuntimeManager.PlayOneShot(inputsound);
        }
    }

    void Start()
    {
        InvokeRepeating("CallFootsteps", 0, walkingSpeed);
    }

    void OnDisable()
    {
        playerIsMoving = false;
    }
}
