using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLOSystem : MonoBehaviour
{
    public float lifetime;
    public bool canDecrease;
    public GameObject lOParticles;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if (lifetime == 0)
        {
            lifetime = 5;
        }
        
        canDecrease = false;

        lOParticles = this.gameObject.transform.Find("MimParticleSystem").gameObject;
        lOParticles.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (canDecrease == true)
        {
            lifetime -= Time.deltaTime;
        }

        if (lifetime <= 0)
        {
            Destroy(this);
        }
        
    }

    private void OnDestroy()
    {
        lOParticles.SetActive(false);
    }
}
