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

    public bool hasTriggered;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (hasTriggered == true)
        {
            PlayerStats.isInteractive = false;
            Debug.Log("Player paralyzed");
            if (PlayerStats.grounded == true)
            {
                SendPlayerToSleep();
            }
            
        }
    }

    public static void Freeze()
    {
        Debug.Log("Go to sleep");
        PlayerStats.isInteractive = false;
        instance.LocalFreeze();

    }

    public void LocalFreeze()
    {
        
        StartCoroutine(SlowFreeze());
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
        if (PlayerStats.grounded == true)
        {
            PlayerStats.player.GetComponent<Animator>().SetTrigger("longSleep");
        }
        
    }

    public IEnumerator SlowFreeze()
    {
        hasTriggered = true;
        yield return new WaitForSeconds(0.5f);
        instance.freezeEvents.Invoke();
        yield return null;
    }
 
    
}
