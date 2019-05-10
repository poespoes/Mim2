using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public KeyCode BackToMenu;
    public KeyCode RestartToCheckPoint;
    public KeyCode NextScene = KeyCode.I;

    private int nextSceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(RestartToCheckPoint)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyUp(BackToMenu)) {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyUp(NextScene)) {
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }
}
