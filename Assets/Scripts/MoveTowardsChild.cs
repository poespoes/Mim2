using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveTowardsChild : MonoBehaviour
{

    public float maxDistance;
    public float distance;
    public Transform currentPos;
    
    // Start is called before the first frame update
    void Start()
    {
        if (maxDistance == 0)
        {
            maxDistance = 30;
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(this.transform.position,PlayerStats.player.transform.position);
        if (distance > maxDistance)
        {
            
            this.transform.DOMove(PlayerStats.player.transform.position,5);
            //this.transform.DOMove(this.gameObject.transform.GetChild(0).transform.position, 5);
           
            currentPos = this.transform;
        }
        else
        {
            //this.transform.DOMove(this.transform.position, 0);
            this.transform.position = currentPos.position;
        }
    }
}
