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

    private void Awake()
    {
        HighestCameraPriority = 11;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
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
            StartCoroutine(RestartAtForcedZoneSequence());
        }
    }

    IEnumerator RestartSequence() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator RestartAtForcedZoneSequence() {
        
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(forceLoadScene);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Debug.Log("CAN RESTART AT FORCED SCENE!");
            restartAtForcedZone = true;
        }
    }
}
