using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRealLeaf : MonoBehaviour
{
    public MimLightToggle mimLightToggle;
    public GameObject mimLeafGameObject;
    public IntroScalelightWhenPressed scaleLeaf;

    public float originalMoveSpeed;
    
    // Start is called before the first frame update

    private void Awake()
    {
        originalMoveSpeed = PlayerStats.moveSpeed;
        
        
        mimLightToggle.enabled = false;
        mimLeafGameObject.SetActive(false);
        scaleLeaf.enabled = false;
        
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.isInteractive == true)
        {
            scaleLeaf.enabled = true;
        }
        
        if (scaleLeaf.maxSizeReached == true)
        {
            mimLightToggle.enabled = true;
            mimLeafGameObject.SetActive(true);
            Destroy(scaleLeaf.gameObject);
        }
    }
}
