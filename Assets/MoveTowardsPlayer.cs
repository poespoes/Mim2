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

    public Vector3 currentPos;

    private void Awake()
    {
        //target = PlayerStats.playerTransform;
        currentPos = this.transform.position;
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
            currentPos = this.transform.position;
            //vineSine.enabled = false;
        }
        else
        {
            //vineSine.enabled = true;
            this.transform.position = this.transform.position;
            RandomMotion();
            
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
        //Vector3 newPos = new Vector3(this.transform.position.x,Mathf.PingPong(Time.deltaTime * 2,0.01f),this.transform.position.z);
        //this.transform.DOMove(newPos, 1);

        transform.position = currentPos+ new Vector3(0, Mathf.Lerp(-3, 3, Mathf.PingPong(Time.time, 1)), 0);
    }

    public IEnumerator WaveMotion()
    {
        yield return  new WaitForSeconds(0.2f);
        
    }
}
