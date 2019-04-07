using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerAwakenAndSleep : MonoBehaviour
{

    public CinemachineVirtualCamera cVcam;
   
    
    // Start is called before the first frame update
    void Start()
    {
        SleepTrigger();

        if (cVcam != null)
        {
            cVcam.m_Priority = GameManager.HighestCameraPriority+1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SleepTrigger()
    {
        if (PlayerStats.startsSleeping == true)
        {
            this.GetComponent<Animator>().SetTrigger("isSleeping");
        }
        
    }

    public void Awaken()
    {
        
    }
}
