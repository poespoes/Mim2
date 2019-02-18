using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChasePlayers : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerStats.player;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tipPos = new Vector3(player.transform.position.x,player.transform.position.y,0);
        this.transform.DOMove(tipPos, 5);
    }
}
