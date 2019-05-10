using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFmod : MonoBehaviour
{
    public bool gameIsOver;
    private bool isDestroyed;
    public NextScene nextScene;

    FMOD.Studio.Bus MasterBus;
    FMOD.Studio.EventInstance Sound;
    

    
    // Start is called before the first frame update
    void Start()
    {
        //MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (gameManager.gameIsOverB == true)
        {
            gameIsOver = true;
            Debug.Log("BGM Off!");
        }*/
        if (nextScene.gameIsOverA == true)
        {
            
            gameIsOver = true;
            Debug.Log("BGM Off!");
        }
        
        if (gameIsOver && !isDestroyed)
        {
            Debug.Log("BGM Off!");

            //this.GetComponent<FMODUnity.StudioEventEmitter>().StopEvent;
            this.GetComponent<FMODUnity.StudioEventEmitter>().Stop();
            isDestroyed = true;
        }
    }
}
