using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMouse : MonoBehaviour {

    Vector3 prevMosuePos;
	public float verticalSpeed;
	public float horizontalSpeed;
    
	void Start () {
        prevMosuePos = Camera.main.ScreenToWorldPoint( Input.mousePosition);

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {
		float h = horizontalSpeed * Input.GetAxisRaw("Mouse X");
		float v = verticalSpeed * Input.GetAxisRaw("Mouse Y");
		
		transform.position = transform.position + new Vector3(h,v,0);

        //transform.position += Camera.main.ScreenToWorldPoint(Input.mousePosition) - prevMosuePos;
        //prevMosuePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
}
