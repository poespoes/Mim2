using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Cinemachine.Examples {
    public class BeamStretch : MonoBehaviour {

        public CinemachineVirtualCamera cineVCam;
        public GameObject lightBeam;
        public float lightFactor;
        float originalOrtho;

        public float maxStretch;

        public float minStretch;

        BeamController beamController;


        // Use this for initialization
        void Start() {
            cineVCam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
            lightBeam = this.transform.Find("MimLight").gameObject;
            //lightFactor = 200;
            originalOrtho = cineVCam.m_Lens.OrthographicSize;

            /*if (maxStretch == null)
            {
                maxStretch = 26.0f;
            }*/

            //minStretch = cineVCam.m_Lens.OrthographicSize;

            beamController = GameObject.Find("MimLight").GetComponent<BeamController>();

        }

        // Update is called once per frame
        void Update() {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 thisPos = this.transform.position;
            
            GameObject v_Mouse = GameObject.Find("VirtualMouse");


            float height = v_Mouse.transform.position.y - thisPos.y;
       

            float distance = Vector3.Distance(v_Mouse.transform.position, thisPos);

            // Constraint the position inside the max range
            if (distance > beamController.currentBeamRange)
                distance = beamController.currentBeamRange;

            //if (Input.GetMouseButtonDown(1)) {

                //Debug.Log("The distance is " + distance);

            float distanceFactor = distance / lightFactor;

            lightBeam.transform.localScale = new Vector3(distanceFactor, 1, 1);

            if (lightBeam.transform.localScale.x > 1.35f)
            {
                lightBeam.transform.localScale = new Vector3(1.35f,1,1);
            }
            
            cineVCam.m_Lens.OrthographicSize = originalOrtho + (distanceFactor * 10);


            if (cineVCam.m_Lens.OrthographicSize < minStretch) {
                cineVCam.m_Lens.OrthographicSize = minStretch;
            }


            if (cineVCam.m_Lens.OrthographicSize < originalOrtho)
            {
                cineVCam.m_Lens.OrthographicSize = originalOrtho;
            }
            else if(cineVCam.m_Lens.OrthographicSize > 24.5f)
            {
                cineVCam.m_Lens.OrthographicSize = 24.5f;
            }

            float heightFactor = (height / lightFactor)+0.5f;
            if (heightFactor > 0.75f)
            {
                heightFactor = 0.75f;
            }

            if (heightFactor < 0.3f)
            {
                heightFactor = 0.4f;
            }

            //}
            
            var cineComposer = cineVCam.GetCinemachineComponent<CinemachineFramingTransposer>();

            //cineComposer.m_ScreenY = cineComposer.m_ScreenY + distanceFactor;

            cineComposer.m_ScreenY = heightFactor;
        }
    }
}