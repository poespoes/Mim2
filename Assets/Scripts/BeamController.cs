using System.Collections;
using System.Collections.Generic;
using Cinemachine.Examples;
using UnityEngine;

public class BeamController : MonoBehaviour
{

    public BeamStretch beamStretch;
    public bool isOn;

    public float shakeRange;
    public Vector2 durationRange;

    float shakeOffset = 0;
    float shakeTimer = 0;

    public float maxBeamRange;
    public float maxHoldDuration;
    public float beamShrinkRate;

    float leftMouseHoldTimer = 0;
    public float currentBeamRange = 0;

    public float minLeafBrightness;

    SpriteRenderer otherBeamSR;
    SpriteRenderer leafSR;
    
    void Start () {
        //Cursor.visible = false;

        beamStretch = GameObject.Find("Player").GetComponent<BeamStretch>();

        otherBeamSR = transform.GetChild(0).GetComponent<SpriteRenderer>();
        leafSR = GameObject.Find("MimLeafON").GetComponent<SpriteRenderer>();
    }
	
	void Update () {
		if (isOn == true)
		{
			Vector3 mousePos = GameObject.Find("VirtualMouse").transform.position;
			mousePos -= transform.position;
			Vector3 euler = transform.eulerAngles;
			euler.z = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
			transform.eulerAngles = euler;
		}

		/*if (Input.GetMouseButtonDown(1)) {
            //toggle light on/off
            //GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            //GetComponent<SpriteMask>().enabled = !GetComponent<SpriteMask>().enabled;

            isOn = !isOn;

            //beamStretch.enabled = !beamStretch.enabled;

        }*/
	    
		GetComponent<SpriteRenderer>().enabled = isOn;
		GetComponent<SpriteMask>().enabled = isOn;
		this.GetComponent<Collider2D>().enabled = isOn;

        // Test for beam shake effect
        if (Input.GetKey(KeyCode.T))
            BeamShake();

        // TODO
        // Lerp the beam thrown-away animation

        // Hold left mouse button to increase the max range of beam
        if (Input.GetMouseButton(0)) {
            leftMouseHoldTimer = Mathf.MoveTowards(leftMouseHoldTimer, maxHoldDuration, Time.deltaTime);
        } else {
            leftMouseHoldTimer = Mathf.MoveTowards(leftMouseHoldTimer, 0, Time.deltaTime * beamShrinkRate);
        }
        isOn = leftMouseHoldTimer > 0;

	    currentBeamRange = Mathf.Lerp(0, maxBeamRange, leftMouseHoldTimer / maxHoldDuration);
        Color c = otherBeamSR.color;
        c.a = currentBeamRange / maxBeamRange;
        otherBeamSR.color = c;
        Vector3 hsv = Vector3.zero;
        Color.RGBToHSV(leafSR.color,out hsv.x, out hsv.y, out hsv.z);
        hsv.z = currentBeamRange / maxBeamRange * (1- minLeafBrightness) + minLeafBrightness;
        leafSR.color = Color.HSVToRGB(hsv.x,hsv.y,hsv.z);
    }

    void BeamShake() {
        shakeTimer -= Time.deltaTime;
        if (shakeTimer < 0) {
            shakeTimer += Random.Range(durationRange.x, durationRange.y);
            if (shakeOffset > 0)
                shakeOffset = -shakeRange;
            else
                shakeOffset = shakeRange;
        }

        Vector3 euler = transform.eulerAngles;
        euler.z += shakeOffset;
        transform.eulerAngles = euler;
    }
    //if playerbeam hit monster, beam shake n turn off
    //
}
