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

    // Start is called before the first frame update
    void Start()
    {
        HighestCameraPriority = 11;
        
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
        StartCoroutine(RestartSequence());
    }

    IEnumerator RestartSequence() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
