using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGswitch : MonoBehaviour {

    FMODUnity.StudioEventEmitter emitter;
    void OnEnable()
    {
        var target = GameObject.Find("BackgroundMusic");
        emitter = target.GetComponent<FMODUnity.StudioEventEmitter>();
    }
    void Update()
    {
        float value = 1.0f; // calculate the value every frame
        emitter.SetParameter("Two", value);
    }
}
