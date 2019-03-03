using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimLeaf : MonoBehaviour
{
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
