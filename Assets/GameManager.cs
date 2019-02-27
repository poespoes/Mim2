using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Mim;
    public bool startFromHere;
    public int Here;

    // Start is called before the first frame update
    void Start()
    {
        if (startFromHere) {
            PlayerPrefs.SetInt("SpawnPointIndex", Here);
        }

        if (PlayerPrefs.GetInt("SpawnPointIndex") == 0) {
            Debug.Log("RESPAWNED!");
            Mim.transform.position = GameObject.Find("CheckPoints").transform.GetChild(PlayerPrefs.GetInt("SpawnPointIndex")).GetComponent<Checkpoint>().SpawnPos.position;
        }
        if (PlayerPrefs.GetInt("SpawnPointIndex") == 1) {
            Debug.Log("RESPAWNED!");
            Mim.transform.position = GameObject.Find("CheckPoints").transform.GetChild(PlayerPrefs.GetInt("SpawnPointIndex")).GetComponent<Checkpoint>().SpawnPos.position;
        }
        if (PlayerPrefs.GetInt("SpawnPointIndex") == 2) {
            Debug.Log("RESPAWNED!");
            Mim.transform.position = GameObject.Find("CheckPoints").transform.GetChild(PlayerPrefs.GetInt("SpawnPointIndex")).GetComponent<Checkpoint>().SpawnPos.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("SpawnPointIndex = "+ PlayerPrefs.GetInt("SpawnPointIndex"));
        //Mim.transform.position = new Vector3(0, 0, 0);
    }

    public void RestartScene() {
        StartCoroutine(RestartSequence());
    }

    IEnumerator RestartSequence() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        /*if(PlayerPrefs.GetInt("SpawnPointIndex") == 1) {
            Debug.Log("RESPAWNED!");
            Mim.transform.position = new Vector3(0, 0, 0);
        }*/

        /*GameObject.Find("Mim").GetComponent<Transform>().transform.position 
            = GameObject.Find("CheckPoints").transform.GetChild(PlayerPrefs.GetInt("SpawnPointIndex")).GetComponent<Checkpoint>().SpawnPos.position;*/
    }
}
