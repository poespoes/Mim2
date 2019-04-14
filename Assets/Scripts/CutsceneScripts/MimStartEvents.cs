using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MimStartEvents : MonoBehaviour
{
    public List<UnityEvent> events;
    private int numberOfEvent;
    private int originalDelayTime;
    public int delayTime;


    public List<MonoBehaviour> listOfScripts;

    public List<GameObject> objectsToDisable;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (delayTime <= 0)
        {
            delayTime = 2;
        }

        if (FindObjectOfType<PlayerStats>() != null)
        {
            PlayerStats.mimLit = false;
        }
        
    }

    void Start()
    {
        StartCoroutine(ExecuteEvent(numberOfEvent));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisablePlayer()
    {
        PlayerStats.isInteractive = false;
    }

    public void EnablePlayer()
    {
        PlayerStats.isInteractive = true;
    }

    public void PlayerIsAsleep()
    {
        PlayerStats.player.GetComponent<Animator>().SetTrigger("longSleep");
    }

    public void PlayerWakeUp()
    {
        PlayerStats.player.GetComponent<Animator>().SetTrigger("isSleeping");
    }

    public void EnableScripts()
    {
        foreach (MonoBehaviour script in listOfScripts)
        {
            script.enabled = true;
        }
    }

    public void DisableScript()
    {
        foreach (MonoBehaviour script in listOfScripts)
        {
            script.enabled = false;
        }
    }

    public void MimLitOff()
    {
        if (FindObjectOfType<PlayerStats>() != null)
        {
            PlayerStats.mimLit = false;
        }
    }

    public IEnumerator ExecuteEvent(int n)
    {
        yield return new WaitForSeconds(originalDelayTime);

        originalDelayTime = delayTime;
        
        events[n].Invoke();

        if (n < events.Count-1)
        {
            numberOfEvent++;
            StartCoroutine(ExecuteEvent(numberOfEvent));
        }
        
    }
}
