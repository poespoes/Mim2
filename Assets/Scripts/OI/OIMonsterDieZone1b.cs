using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OIMonsterDieZone1b : MonoBehaviour
{
    public Zone1bScaleLight Zone1bScaleLight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Zone1bScaleLight.maxSizeReached) {
            Destroy(this);
        }
    }
}
