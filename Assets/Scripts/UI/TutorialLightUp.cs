using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLightUp : MonoBehaviour
{
    public IntroScalelightWhenPressed script;
    public Zone1bScaleLight script2;
    public bool zone1B;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (script.maxSizeReached) {
            this.gameObject.SetActive(false);
        }

        if (script2.maxSizeReached) {
            this.gameObject.SetActive(false);
            Debug.Log("tutorialCOMPLETE!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Invoke("TurnOnTutorial", 5);
    }

    void TurnOnTutorial() {
        button.SetActive(true);
    }
}
