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
    
    
    void Start() {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        thisNextScene = this;

        thisScene = SceneManager.GetActiveScene().name;
    }


    void Update() {
        if (SceneManager.GetActiveScene().buildIndex == 0 && Input.GetButton("Fire1")) {
            anim.SetTrigger("isFadingOut");
        }
        /*if (SceneManager.GetActiveScene().buildIndex == 0 && Input.GetKeyDown(KeyCode.Space)) {
            anim.SetTrigger("isFadingOut");
        }*/
        
        if (thisScene == ("TempEndScene") && Input.GetButton("Jump")) {
            SceneManager.LoadScene("Menu");
        }
        /*if (SceneManager.GetActiveScene().buildIndex == 7 && Input.GetButton("Jump")) {
            SceneManager.LoadScene("Menu");
        }*/
        /*if (Input.GetKeyDown(KeyCode.Space)) {
            anim.SetTrigger("isFadingOut");
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        anim.SetTrigger("isFadingOut");
        FreezePlayer.Freeze();
    }

    public void IsFadingOut()
    {
        anim.SetTrigger("isFadingOut");
    }

    private void LoadScene() {
        if (forcingLoadScene == true) {
            SceneManager.LoadScene(forceLoadScene);
        } else {
            SceneManager.LoadScene(nextSceneToLoad);
        }
        
    }
}
