using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class FreezePlayer : MonoBehaviour
{

    public static FreezePlayer instance;

    public Transform PlayerMovTransform;

    public UnityEvent freezeEvents;

    private void Awake()
    {
        instance = this;
    }

    public static void Freeze()
    {
        Debug.Log("Go to sleep");
        PlayerStats.isInteractive = false;
        instance.freezeEvents.Invoke();

    }

    public void MovePlayer()
    {
        if (PlayerMovTransform != null)
        {
            PlayerStats.player.transform.DOMove(PlayerMovTransform.position, 1);
        }
        
    }

    public void SendPlayerToSleep()
    {
        PlayerStats.player.GetComponent<Animator>().SetTrigger("isSleeping");
    }
 
    
}
