using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poe_OISpawner : MonoBehaviour
{

    public List<Sprite> spriteList;
    public float frameDuration;
    public float frameReverseDuration;
    public bool isLightened = false;
    float timer = 0;
    int currentIndex = 0;

    public OISpawner _oiSpawner;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {

        isLightened = PlayerStats.mimLit;

        timer += Time.deltaTime;

        if (_oiSpawner._mySon == null)
        {



            if (isLightened == false)
            {
                if (timer >= frameDuration)
                {
                    timer -= frameDuration;
                    if (currentIndex + 1 < spriteList.Count)
                    {
                        currentIndex++;
                    }

                    GetComponent<SpriteRenderer>().sprite = spriteList[currentIndex];

                    if (currentIndex + 1 == spriteList.Count)
                    {
                        Debug.Log("New Spawn OI called");
                        _oiSpawner.newSpawnOI();
                    }
                }
            }
            else
            {
                if (timer >= frameReverseDuration)
                {
                    timer -= frameReverseDuration;
                    if (currentIndex - 1 >= 0)
                    {
                        currentIndex--;
                    }

                    GetComponent<SpriteRenderer>().sprite = spriteList[currentIndex];
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        isLightened = true;
        timer = 0;
    }

    void OnTriggerExit(Collider other) {
        isLightened = false;
        timer = 0;
    }
}
