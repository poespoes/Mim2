using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    FMOD.Studio.Bus MasterBus;

    // Start is called before the first frame update
    void Start()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyUp(KeyCode.B)) {
            MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }*/
        
    }
}
