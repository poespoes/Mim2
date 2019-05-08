using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Mim;
    public bool startFromHere;
    public int Here;

    public static int HighestCameraPriority;
    public static CinemachineVirtualCamera currentCam;
    public static CinemachineVirtualCamera prevCam;

    public bool restartAtForcedZone;
    public bool canRestartAtForcedZone;

    public string forceLoadScene;
    public bool canLoad;

    private void Awake()
    {
        HighestCameraPriority = 11;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (canRestartAtForcedZone) {
            Debug.Log("LOADING CHECKPOINT IN BACKGROUND");
            StartCoroutine(LoadYourAsyncScene());
        }

        if (startFromHere) {
            PlayerPrefs.SetInt("SpawnPointIndex", Here);
        }

            Debug.Log("RESPAWNED!");
            Mim.transform.position = GameObject.Find("CheckPoints").transform.GetChild(PlayerPrefs.GetInt("SpawnPointIndex")).GetComponent<Checkpoint>().SpawnPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("SpawnPointIndex = "+ PlayerPrefs.GetInt("SpawnPointIndex"));

    }

    public void RestartScene() {
        if (restartAtForcedZone == false) {
            StartCoroutine(RestartSequence());
        }
        if (restartAtForcedZone == true) {
            canLoad = true;
            StartCoroutine(RestartAtForcedZoneSequence());
        }
    }

    IEnumerator RestartSequence() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resources.UnloadUnusedAssets();
    }
    IEnumerator RestartAtForcedZoneSequence() {
        
        yield return new WaitForSeconds(3);
        canLoad = true;
        //SceneManager.LoadScene(forceLoadScene);
        //StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene() {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(forceLoadScene);
        asyncLoad.allowSceneActivation = false;
        //Debug.Log("Pro :" + asyncLoad.progress);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
            yield return null;

            if (asyncLoad.progress >= 0.9f && canLoad) {
                asyncLoad.allowSceneActivation = true;
            }
            //SceneManager.UnloadSceneAsync("forceLoadScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Debug.Log("CAN RESTART AT FORCED SCENE!");
            restartAtForcedZone = true;
        }
    }
}
