using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineFadeSound : MonoBehaviour {

    FMOD.Studio.EventInstance Sound;

    void Start()
    {
        Sound = FMODUnity.RuntimeManager.CreateInstance("event:/Mim/Vine/VineApproach");
    }

    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Sound, GetComponent<Transform>(), GetComponent<Rigidbody2D>());
    }

    void OnMouseDown()
    {
        Debug.Log("trigger enter");
        Sound.start();
    }

    void OnMouseUp()
    {
        StartCoroutine(fadeOut());
        //Sound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Debug.Log("trigger exit");
    }

    float vol;
    float finalVol;
    IEnumerator fadeOut()
    {
        Sound.getVolume(out vol, out finalVol);
        vol = vol - .005f;
        Sound.setVolume(vol);
        yield return null;
        if (vol <= 0) yield break;
        yield return fadeOut();
    }
}
