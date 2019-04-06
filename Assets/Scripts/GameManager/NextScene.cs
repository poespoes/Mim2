using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
    public Animator anim;
    private int nextSceneToLoad;


    void Start() {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }


    void Update() {
        if (SceneManager.GetActiveScene().buildIndex == 0 && Input.GetButton("Fire1")) {
            anim.SetTrigger("isFadingOut");
        }
        /*if (SceneManager.GetActiveScene().buildIndex == 0 && Input.GetKeyDown(KeyCode.Space)) {
            anim.SetTrigger("isFadingOut");
        }*/

        if (SceneManager.GetActiveScene().buildIndex == 7 && Input.GetButton("Jump")) {
            SceneManager.LoadScene("Menu");
        }
        /*if (Input.GetKeyDown(KeyCode.Space)) {
            anim.SetTrigger("isFadingOut");
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        anim.SetTrigger("isFadingOut");
        FreezePlayer.Freeze();
    }

    private void LoadScene() {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
