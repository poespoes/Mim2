using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{

    public Transform target;
    public bool isTriggered;
    public VineSine vineSine;
    public float timeToEnd;


    private void Awake()
    {
        //target = PlayerStats.playerTransform;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (timeToEnd == 0)
        {
            timeToEnd = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered == true && target!=null)
        {
            Chase();
            //vineSine.enabled = false;
        }
        else
        {
            //vineSine.enabled = true;
            this.transform.position = this.transform.position;
            
        }
    }

    public void Chase()
    {
        //this.transform.DOMove(target.position, 2);

        this.transform.DOMoveX(target.position.x, timeToEnd);
        this.transform.DOMoveY(target.position.y, timeToEnd);
    }

    public void RandomMotion()
    {
        
    }
}
