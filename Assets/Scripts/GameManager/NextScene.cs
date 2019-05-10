using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
    public Animator anim;
    private int nextSceneToLoad;

    private string thisScene;
    public bool forcingLoadScene;
    public string forceLoadScene;

    public static NextScene thisNextScene;
    public bool gameIsOverA = false;

    FMOD.Studio.Bus MasterBus;
    FMOD.Studio.EventInstance Sound;

    void Start() {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        thisNextScene = this;

        thisScene = SceneManager.GetActiveScene().name;

        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
    }


    void Update() {
        /*if (SceneManager.GetActiveScene().buildIndex == 0 && Input.GetButton("Fire1")) {
            anim.SetTrigger("isFadingOut");
        }*/
        if (SceneManager.GetActiveScene().buildIndex == 0 && Input.anyKey) {
            anim.SetTrigger("isFadingOut2");
            gameIsOverA = true;
        }
        /*if (SceneManager.GetActiveScene().buildIndex == 0 && Input.GetKeyDown(KeyCode.Space)) {
            anim.SetTrigger("isFadingOut");
        }*/
        
        if (thisScene == ("TempEndScene") && Input.GetButton("Jump")) {
            SceneManager.LoadScene("Menu");
            gameIsOverA = true;
        }
        /*if (SceneManager.GetActiveScene().buildIndex == 7 && Input.GetButton("Jump")) {
            SceneManager.LoadScene("Menu");
        }*/
        /*if (Input.GetKeyDown(KeyCode.Space)) {
            anim.SetTrigger("isFadingOut");
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        anim.SetTrigger("isFadingOut2");
        FreezePlayer.Freeze();
    }

    public void IsFadingOut()
    {
        anim.SetTrigger("isFadingOut2");
    }

    public void TurnOffMusic()
    {
        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    private void LoadScene() {
        if (forcingLoadScene == true) {
            //gameIsOverA = true;
            anim.SetTrigger("isFadingOut2");
            SceneManager.LoadScene(forceLoadScene);
        } else {
            //gameIsOverA = true;
            anim.SetTrigger("isFadingOut2");
            SceneManager.LoadScene(nextSceneToLoad);
        }
        
    }
}
