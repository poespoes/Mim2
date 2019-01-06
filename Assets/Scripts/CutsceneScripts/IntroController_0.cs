using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController_0 : MonoBehaviour {

    private float timer;
    private bool isBlackout = false;
    public float timeTilBlackout;
    public float timeTilCutMusic;
    public float timeTilChangeScene;

    public Image blackOutCanvas;

    // Use this for initialization
    void Start() {
        blackOutCanvas = GameObject.Find("BlackoutPanel").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;

        if (timer >= timeTilBlackout && isBlackout == false) {
            Debug.Log("Blacking out!");
            isBlackout = true;
            blackOutCanvas.CrossFadeAlpha(254, 8, false);
        }
        if (timer >= timeTilBlackout + timeTilCutMusic) {
            Debug.Log("Music stops!");
            //stop music
            //plays mom's grasp sound
        }
        if (timer >= timeTilBlackout + timeTilCutMusic + timeTilChangeScene) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    /*void blackOut()
	{
		blackOutCanvas.CrossFadeAlpha(255,5,false);
		Invoke("NextScene",4);
	}

	void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}*/
}
