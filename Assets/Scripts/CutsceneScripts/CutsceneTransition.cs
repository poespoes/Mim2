using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTransition : MonoBehaviour
{

    public List<GameObject> objectsToEnable;
    public List<GameObject> objectsToDisable;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        foreach (GameObject objectToDisable in objectsToDisable)
        {
            objectToDisable.SetActive(false);
        }
        
        foreach (GameObject objectToEnable in objectsToEnable)
        {
            objectToEnable.SetActive(true);
        }
    }

    public void FadeSprites(GameObject _gameObject)
    {
        
      
        
        
    }
    
    
}
