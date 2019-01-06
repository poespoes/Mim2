using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oi_1Movement : MonoBehaviour {
    public float startingSpeed;
    public float SpeedMultiplier;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        //rb.AddForce(transform.right * (startingSpeed * SpeedMultiplier));


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            //something happens
        }
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}