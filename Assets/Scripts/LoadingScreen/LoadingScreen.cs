using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public string sceneToLoad;
    public string thisScene;

    public bool startOnLoad;

    public bool useTimer;
    public float maxTimer;
    public float timer;
    

    void Start()
    {
        thisScene = SceneManager.GetActiveScene().name;
    }

    void Update() {
        if (useTimer) {
            timer += Time.deltaTime;
        }

        if (startOnLoad) {
            StartCoroutine(LoadYourAsyncScene());
            startOnLoad = false;
        }
    }

    IEnumerator LoadYourAsyncScene() {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
            yield return null;

            if (asyncLoad.progress >= 0.9f && useTimer && timer >= maxTimer) {
                asyncLoad.allowSceneActivation = true;
            }
            if (asyncLoad.progress >= 0.9f && !useTimer) {
                asyncLoad.allowSceneActivation = true;
            }
            //SceneManager.UnloadSceneAsync("forceLoadScene");
        }
    }
}