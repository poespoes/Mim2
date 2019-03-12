using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
//using Cinemachine.Editor;

public class EnterSafeZone : MonoBehaviour
{
    public CinemachineVirtualCamera cm2;
    public int priority;
    public bool dynamic;
    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera forcedPrevCam;
    
    public enum CameraItGoesBackTo
    {
        MainCam,
        PrevCam,
    }

    public bool end;

    public CameraItGoesBackTo _CameraItGoesBackTo;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.Find("MainVirtualCamera").GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (GameManager.currentCam != cm2)
            {
                GameManager.prevCam = GameManager.currentCam;
                GameManager.currentCam = cm2;
            }
            
            GameManager.HighestCameraPriority += 1;
            
            
            priority = GameManager.HighestCameraPriority;
            cm2.Priority = priority;

            if (dynamic == true)
            {
                cm2.m_Follow = other.transform;
            }

            if (end == true) //turns player off and puts them to sleep
            {
                //PlayerStats.isInteractive = false;
                other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                other.GetComponent<Animator>().SetTrigger("isSleeping");
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.HighestCameraPriority += 1;
            priority = GameManager.HighestCameraPriority;

            if (_CameraItGoesBackTo == CameraItGoesBackTo.MainCam)
            {
                mainCam.Priority = priority;
            }
            else
            {
                if (GameManager.prevCam != null)
                {
                    GameManager.prevCam.Priority = priority;
                }
                else
                {
                    forcedPrevCam.Priority = priority;
                }
                
            }
            

            

        }
    }
}
