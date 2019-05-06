using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimLeaf : MonoBehaviour
{
    public Animator anim;
    public GameObject mimLeafPointer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = mimLeafPointer.transform.position;
        this.transform.rotation = mimLeafPointer.transform.rotation;
        
    }

    private void LateUpdate()
    {
        if (PlayerStats.mimLit == true)
        {
            anim.SetBool("LeafON",false);
            anim.SetBool("LeafOFF",true);
        }
        else
        {
            anim.SetBool("LeafON",true);
            anim.SetBool("LeafOFF",false);
                
        }

        if(PlayerStats.leafDead == true) {
            anim.SetBool("LeafRED", true);
        }

      
    }

    public void MimLightTurnsOn()
    {
        PlayerStats.vineCanChase = true;
        Debug.Log("LightBringer");
    }

    public void MimLIghtTurnsOff()
    {
        PlayerStats.vineCanChase = false;
        Debug.Log("Arthas");
    }
}
