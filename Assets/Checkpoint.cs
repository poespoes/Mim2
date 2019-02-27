using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public int SpawnPointIndex;
    public Transform SpawnPos;

     void OnTriggerEnter2D(Collider2D collision) {
        PlayerPrefs.SetInt("SpawnPointIndex", SpawnPointIndex);
    }
}
